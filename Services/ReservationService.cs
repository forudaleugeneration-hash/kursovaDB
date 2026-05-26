using System.Data;
using LibraryApp.Database;
using LibraryApp.Models;

namespace LibraryApp.Services
{
    public class ReservationService
    {
        private static readonly Random _random = new Random();

        // Генерация случайного кода из 8 символов (цифры + буквы)
        public string GenerateReservationCode()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789"; // Без похожих символов (0/O, 1/I)
            char[] code = new char[8];
            for (int i = 0; i < code.Length; i++)
            {
                code[i] = chars[_random.Next(chars.Length)];
            }
            return new string(code);
        }

        // Создание бронирования (вызывается пользователем)
        public string? ReserveBook(int userId, int bookId)
        {
            // Проверяем, доступна ли книга
            string checkQuery = $"SELECT IsAvailable FROM Books WHERE BookId = {bookId}";
            var result = DatabaseHelper.ExecuteScalar(checkQuery);

            if (result == null || !Convert.ToBoolean(result))
                return null; // Книга недоступна

            // Проверяем, нет ли уже активного бронирования у этого пользователя на эту книгу
            string checkReservation = $@"SELECT COUNT(*) FROM Reservations 
                                        WHERE UserId = {userId} AND BookId = {bookId} 
                                        AND Status = N'Активно' AND ExpiryDate > GETDATE()";
            var existingReservation = DatabaseHelper.ExecuteScalar(checkReservation);

            if (existingReservation != null && Convert.ToInt32(existingReservation) > 0)
                return "ALREADY_RESERVED"; // Уже есть активное бронирование

            // Генерируем уникальный код
            string code = GenerateReservationCode();

            // Убеждаемся, что код уникален (повторяем генерацию при совпадении)
            while (Convert.ToInt32(DatabaseHelper.ExecuteScalar($"SELECT COUNT(*) FROM Reservations WHERE ReservationCode = '{code}'")) > 0)
            {
                code = GenerateReservationCode();
            }

            // Срок действия — 3 дня
            DateTime expiryDate = DateTime.Now.AddDays(3);

            // Создаём бронирование
            string query = $@"INSERT INTO Reservations (ReservationCode, UserId, BookId, ExpiryDate) 
                             VALUES ('{code}', {userId}, {bookId}, '{expiryDate:yyyy-MM-dd HH:mm:ss}')";
            DatabaseHelper.ExecuteNonQuery(query);

            // Делаем книгу недоступной для бронирования другими
            query = $"UPDATE Books SET IsAvailable = 0 WHERE BookId = {bookId}";
            DatabaseHelper.ExecuteNonQuery(query);

            return code; // Возвращаем код бронирования
        }

        // Отмена бронирования пользователем
        public bool CancelReservation(int userId, string reservationCode)
        {
            string query = $@"UPDATE Reservations SET Status = N'Отменено' 
                             WHERE ReservationCode = '{reservationCode}' 
                             AND UserId = {userId} AND Status = N'Активно'";

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query);

            if (rowsAffected > 0)
            {
                // Освобождаем книгу
                string freeBookQuery = $@"UPDATE Books SET IsAvailable = 1 
                                         WHERE BookId = (SELECT BookId FROM Reservations WHERE ReservationCode = '{reservationCode}')";
                DatabaseHelper.ExecuteNonQuery(freeBookQuery);
                return true;
            }
            return false;
        }

        // Подтверждение бронирования библиотекарем/админом (выдача книги)
        public bool ConfirmReservation(string reservationCode, int librarianId)
        {
            // Проверяем, существует ли активное бронирование с таким кодом
            string checkQuery = $@"SELECT ReservationId, UserId, BookId, Status, ExpiryDate 
                                   FROM Reservations 
                                   WHERE ReservationCode = '{reservationCode}'";

            var dt = DatabaseHelper.ExecuteQuery(checkQuery);

            if (dt.Rows.Count == 0) return false;

            var row = dt.Rows[0];
            string status = row["Status"]?.ToString() ?? "";
            DateTime expiryDate = Convert.ToDateTime(row["ExpiryDate"]);

            // Проверяем статус и срок действия
            if (status != "Активно" || DateTime.Now > expiryDate)
            {
                // Если просрочено — обновляем статус
                if (status == "Активно" && DateTime.Now > expiryDate)
                {
                    DatabaseHelper.ExecuteNonQuery($"UPDATE Reservations SET Status = N'Просрочено' WHERE ReservationCode = '{reservationCode}'");
                }
                return false;
            }

            int userId = Convert.ToInt32(row["UserId"]);
            int bookId = Convert.ToInt32(row["BookId"]);

            // Создаём запись о выдаче книги (аренда)
            string loanQuery = $@"INSERT INTO Loans (UserId, BookId, DueDate, Status) 
                                 VALUES ({userId}, {bookId}, '{DateTime.Now.AddDays(14):yyyy-MM-dd}', N'Выдана')";
            DatabaseHelper.ExecuteNonQuery(loanQuery);

            // Обновляем статус бронирования
            string updateReservationQuery = $@"UPDATE Reservations SET Status = N'Выдано', LibrarianId = {librarianId} 
                                              WHERE ReservationCode = '{reservationCode}'";
            DatabaseHelper.ExecuteNonQuery(updateReservationQuery);

            return true;
        }

        // Получение информации о бронировании по коду
        public Reservation? GetReservationByCode(string code)
        {
            string query = $@"SELECT r.*, u.Username, b.Title as BookTitle, a.AuthorName,
                             l.Username as LibrarianName
                             FROM Reservations r 
                             INNER JOIN Users u ON r.UserId = u.UserId 
                             INNER JOIN Books b ON r.BookId = b.BookId 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             LEFT JOIN Users l ON r.LibrarianId = l.UserId 
                             WHERE r.ReservationCode = '{code}'";

            var dt = DatabaseHelper.ExecuteQuery(query);

            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new Reservation
            {
                ReservationId = Convert.ToInt32(row["ReservationId"]),
                ReservationCode = row["ReservationCode"]?.ToString() ?? "",
                UserId = Convert.ToInt32(row["UserId"]),
                Username = row["Username"]?.ToString() ?? "",
                BookId = Convert.ToInt32(row["BookId"]),
                BookTitle = row["BookTitle"]?.ToString() ?? "",
                AuthorName = row["AuthorName"]?.ToString() ?? "",
                ReservationDate = Convert.ToDateTime(row["ReservationDate"]),
                ExpiryDate = Convert.ToDateTime(row["ExpiryDate"]),
                Status = row["Status"]?.ToString() ?? "",
                LibrarianId = row["LibrarianId"] != DBNull.Value ? Convert.ToInt32(row["LibrarianId"]) : null,
                LibrarianName = row["LibrarianName"]?.ToString() ?? ""
            };
        }

        // Получение активных бронирований пользователя
        public List<Reservation> GetUserReservations(int userId)
        {
            var reservations = new List<Reservation>();
            string query = $@"SELECT r.*, u.Username, b.Title as BookTitle, a.AuthorName
                             FROM Reservations r 
                             INNER JOIN Users u ON r.UserId = u.UserId 
                             INNER JOIN Books b ON r.BookId = b.BookId 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             WHERE r.UserId = {userId} 
                             ORDER BY r.ReservationDate DESC";

            var dt = DatabaseHelper.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                reservations.Add(new Reservation
                {
                    ReservationId = Convert.ToInt32(row["ReservationId"]),
                    ReservationCode = row["ReservationCode"]?.ToString() ?? "",
                    UserId = Convert.ToInt32(row["UserId"]),
                    Username = row["Username"]?.ToString() ?? "",
                    BookId = Convert.ToInt32(row["BookId"]),
                    BookTitle = row["BookTitle"]?.ToString() ?? "",
                    AuthorName = row["AuthorName"]?.ToString() ?? "",
                    ReservationDate = Convert.ToDateTime(row["ReservationDate"]),
                    ExpiryDate = Convert.ToDateTime(row["ExpiryDate"]),
                    Status = row["Status"]?.ToString() ?? ""
                });
            }
            return reservations;
        }

        // Получение всех активных бронирований (для админа)
        public DataTable GetAllActiveReservations()
        {
            return DatabaseHelper.ExecuteQuery(@"SELECT r.ReservationCode, r.ReservationDate, r.ExpiryDate, r.Status,
                                                b.Title, a.AuthorName, u.Username, u.FullName
                                                FROM Reservations r 
                                                INNER JOIN Books b ON r.BookId = b.BookId 
                                                INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                                                INNER JOIN Users u ON r.UserId = u.UserId 
                                                WHERE r.Status = N'Активно' 
                                                ORDER BY r.ReservationDate DESC");
        }

        // Обновление просроченных бронирований (освобождение книг)
        public void UpdateExpiredReservations()
        {
            string query = @"UPDATE Books SET IsAvailable = 1 
                            WHERE BookId IN (
                                SELECT BookId FROM Reservations 
                                WHERE Status = N'Активно' AND ExpiryDate < GETDATE()
                            )";
            DatabaseHelper.ExecuteNonQuery(query);

            query = @"UPDATE Reservations SET Status = N'Просрочено' 
                     WHERE Status = N'Активно' AND ExpiryDate < GETDATE()";
            DatabaseHelper.ExecuteNonQuery(query);
        }
    }
}