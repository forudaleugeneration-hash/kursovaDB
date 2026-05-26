using System.Data;
using LibraryApp.Database;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class UserService
    {
        public User? Login(string username, string password)
        {
            string query = $@"SELECT * FROM Users 
                             WHERE Username = N'{username.Replace("'", "''")}' 
                             AND Password = N'{password.Replace("'", "''")}' AND IsActive = 1";
            var dt = DatabaseHelper.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    Username = row["Username"]?.ToString() ?? string.Empty,
                    Password = "",
                    Email = row["Email"]?.ToString() ?? string.Empty,
                    FullName = row["FullName"]?.ToString() ?? string.Empty,
                    RegistrationDate = Convert.ToDateTime(row["RegistrationDate"]),
                    IsActive = true,
                    RoleId = row["RoleId"] != DBNull.Value ? Convert.ToInt32(row["RoleId"]) : 3
                };
            }
            return null;
        }

        public bool Register(string username, string password, string email = "", string fullName = "")
        {
            var result = DatabaseHelper.ExecuteScalar($"SELECT COUNT(*) FROM Users WHERE Username = N'{username.Replace("'", "''")}'");
            if (result != null && Convert.ToInt32(result) > 0) return false;
            string query = $@"INSERT INTO Users (Username, Password, Email, FullName, RoleId) 
                             VALUES (N'{username.Replace("'", "''")}', N'{password.Replace("'", "''")}', 
                                     N'{email.Replace("'", "''")}', N'{fullName.Replace("'", "''")}', 3)";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }

        public List<Loan> GetActiveLoans(int userId)
        {
            var loans = new List<Loan>();
            string query = $@"SELECT l.*, b.Title, a.AuthorName, b.BookType, 
                             CASE WHEN b.PdfContent IS NOT NULL THEN 1 ELSE 0 END as HasPdf
                             FROM Loans l 
                             INNER JOIN Books b ON l.BookId = b.BookId 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             WHERE l.UserId = {userId} AND l.Status IN (N'Выдана', N'Забронирована') 
                             ORDER BY l.LoanDate DESC";
            var dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                loans.Add(new Loan
                {
                    LoanId = Convert.ToInt32(row["LoanId"]),
                    BookId = Convert.ToInt32(row["BookId"]),
                    UserId = userId,
                    BookTitle = row["Title"]?.ToString() ?? string.Empty,
                    AuthorName = row["AuthorName"]?.ToString() ?? string.Empty,
                    LoanDate = Convert.ToDateTime(row["LoanDate"]),
                    DueDate = Convert.ToDateTime(row["DueDate"]),
                    Status = row["Status"]?.ToString() ?? "Выдана",
                    IsOnline = row["IsOnline"] != DBNull.Value && Convert.ToBoolean(row["IsOnline"]),
                    BookType = row.Table.Columns.Contains("BookType") ? row["BookType"]?.ToString() ?? "Печатная" : "Печатная",
                    HasPdf = row.Table.Columns.Contains("HasPdf") && Convert.ToInt32(row["HasPdf"]) == 1,
                    ReservationCode = row.Table.Columns.Contains("ReservationCode") ? row["ReservationCode"]?.ToString() : null
                });
            }
            return loans;
        }

        public List<Book> GetReadHistory(int userId)
        {
            var books = new List<Book>();
            string query = $@"SELECT b.*, a.AuthorName, g.GenreName, rh.ReadDate 
                             FROM ReadHistory rh 
                             INNER JOIN Books b ON rh.BookId = b.BookId 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             INNER JOIN Genres g ON b.GenreId = g.GenreId 
                             WHERE rh.UserId = {userId} ORDER BY rh.ReadDate DESC";
            var dt = DatabaseHelper.ExecuteQuery(query);
            var bookService = new BookService();
            foreach (DataRow row in dt.Rows) books.Add(bookService.MapBook(row));
            return books;
        }

        public List<Book> GetBookmarks(int userId)
        {
            var books = new List<Book>();
            string query = $@"SELECT b.*, a.AuthorName, g.GenreName 
                             FROM Bookmarks bm 
                             INNER JOIN Books b ON bm.BookId = b.BookId 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             INNER JOIN Genres g ON b.GenreId = g.GenreId 
                             WHERE bm.UserId = {userId} ORDER BY bm.DateAdded DESC";
            var dt = DatabaseHelper.ExecuteQuery(query);
            var bookService = new BookService();
            foreach (DataRow row in dt.Rows) books.Add(bookService.MapBook(row));
            return books;
        }

        public string BorrowBook(int userId, int bookId)
        {
            var bookService = new BookService();
            var book = bookService.GetBookById(bookId);
            if (book == null) return string.Empty;

            if (book.BookType == "Онлайн")
            {
                var dueDate = DateTime.Now.AddDays(30);
                string query = $@"INSERT INTO Loans (UserId, BookId, DueDate, Status, IsOnline) 
                                 VALUES ({userId}, {bookId}, '{dueDate:yyyy-MM-dd}', N'Выдана', 1)";
                DatabaseHelper.ExecuteNonQuery(query);
                DatabaseHelper.ExecuteNonQuery($"UPDATE Books SET Popularity = Popularity + 1 WHERE BookId = {bookId}");
                return "ONLINE";
            }
            else
            {
                if (book.AvailableCopies <= 0) return "NO_COPIES";
                var adminService = new AdminService();
                string code = adminService.CreateReservation(userId, bookId);
                DatabaseHelper.ExecuteNonQuery($"UPDATE Books SET Popularity = Popularity + 1 WHERE BookId = {bookId}");
                return code;
            }
        }

        public bool ReturnBook(int userId, int bookId)
        {
            string checkQuery = $@"SELECT l.LoanId, l.IsOnline FROM Loans l 
                                  WHERE l.UserId = {userId} AND l.BookId = {bookId} AND l.Status = N'Выдана'";
            var dt = DatabaseHelper.ExecuteQuery(checkQuery);
            if (dt.Rows.Count == 0) return false;

            bool isOnline = Convert.ToBoolean(dt.Rows[0]["IsOnline"]);
            if (!isOnline) return false;

            int loanId = Convert.ToInt32(dt.Rows[0]["LoanId"]);
            DatabaseHelper.ExecuteNonQuery($"UPDATE Loans SET Status = N'Возвращена', ReturnDate = GETDATE() WHERE LoanId = {loanId}");
            DatabaseHelper.ExecuteNonQuery($@"IF NOT EXISTS (SELECT 1 FROM ReadHistory WHERE UserId = {userId} AND BookId = {bookId})
                                             INSERT INTO ReadHistory (UserId, BookId) VALUES ({userId}, {bookId})");
            return true;
        }

        public void AddBookmark(int userId, int bookId)
        {
            var result = DatabaseHelper.ExecuteScalar($"SELECT COUNT(*) FROM Bookmarks WHERE UserId = {userId} AND BookId = {bookId}");
            if (result != null && Convert.ToInt32(result) == 0)
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Bookmarks (UserId, BookId) VALUES ({userId}, {bookId})");
        }

        public void RemoveBookmark(int userId, int bookId)
        {
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM Bookmarks WHERE UserId = {userId} AND BookId = {bookId}");
        }

        public void AddReview(int userId, int bookId, int rating, string comment)
        {
            string query = $@"INSERT INTO Reviews (UserId, BookId, Rating, Comment) 
                             VALUES ({userId}, {bookId}, {rating}, N'{comment.Replace("'", "''")}')";
            DatabaseHelper.ExecuteNonQuery(query);
            var bookService = new BookService();
            bookService.UpdateBookRating(bookId);
        }
    }
}