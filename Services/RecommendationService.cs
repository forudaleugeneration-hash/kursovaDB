using System.Data;                             // DataTable, DataRow — работа с результатами SQL-запросов
using LibraryApp.Database;                     // DatabaseHelper — выполнение запросов к базе данных
using LibraryApp.Models;                       // Book — модель данных книги

namespace LibraryApp.Services
{
    public class RecommendationService         // Сервис персональных рекомендаций на основе истории чтения
    {
        private readonly BookService _bookService; // Сервис книг для MapBook() и GetPopularBooks()

        public RecommendationService()          // Конструктор — создаёт BookService при создании сервиса
        {
            _bookService = new BookService();
        }

        public List<Book> GetPersonalRecommendations(int userId) // Главный метод: персональные рекомендации
        {
            int? favoriteGenreId = GetFavoriteGenre(userId);    // Находим ID самого читаемого жанра

            if (favoriteGenreId.HasValue)                        // Если любимый жанр найден
            {
                return GetBooksByGenre(favoriteGenreId.Value, userId); // Рекомендуем книги этого жанра
            }

            return _bookService.GetPopularBooks(10);             // Если истории чтения нет — популярные книги
        }

        private int? GetFavoriteGenre(int userId) // Определить ID самого читаемого жанра; int? — может быть null
        {
            // ставлю комментарии по SQL-запросам выше самого запроса, в запросе он выдаёт ошибку
            // TOP 1 — только одна строка (самый читаемый жанр)
            // COUNT(*) — сколько книг прочитано в каждом жанре
            // GROUP BY b.GenreId — группировка по жанру для подсчёта
            // ORDER BY GenreCount DESC — жанр с наибольшим количеством сверху
            string query = $@"SELECT TOP 1 b.GenreId, COUNT(*) as GenreCount
                             FROM ReadHistory rh 
                             INNER JOIN Books b ON rh.BookId = b.BookId 
                             WHERE rh.UserId = {userId} 
                             GROUP BY b.GenreId 
                             ORDER BY GenreCount DESC";

            var dt = DatabaseHelper.ExecuteQuery(query);         // Выполняем SQL-запрос
            if (dt.Rows.Count > 0 && dt.Rows[0]["GenreId"] != DBNull.Value) // Если нашли жанр и он не NULL
            {
                return Convert.ToInt32(dt.Rows[0]["GenreId"]);  // object → int, возвращаем ID жанра
            }
            return null;                                         // Жанр не найден
        }

        private List<Book> GetBooksByGenre(int genreId, int userId) // Получить книги конкретного жанра
        {
            var books = new List<Book>();
            // TOP 10 — максимум 10 книг
            // WHERE b.GenreId = {genreId} — только книги этого жанра
            // NOT IN (SELECT ... FROM ReadHistory) — исключаем уже прочитанные
            // ORDER BY b.Rating DESC, b.Popularity DESC — лучшие по рейтингу и популярности сверху
            string query = $@"SELECT TOP 10 b.*, a.AuthorName, g.GenreName 
                             FROM Books b 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             INNER JOIN Genres g ON b.GenreId = g.GenreId 
                             WHERE b.GenreId = {genreId} 
                             AND b.BookId NOT IN (
                                 SELECT BookId FROM ReadHistory WHERE UserId = {userId}
                             )
                             ORDER BY b.Rating DESC, b.Popularity DESC";

            var dt = DatabaseHelper.ExecuteQuery(query);

            if (dt.Rows.Count < 5)                               // Если книг этого жанра меньше 5
            {
                // TOP {10 - dt.Rows.Count} — добираем сколько не хватает до 10
                // AND b.GenreId != {genreId} — книги ДРУГИХ жанров
                // NOT IN (SELECT ... FROM ReadHistory) — не прочитанные
                string popularQuery = $@"SELECT TOP {10 - dt.Rows.Count} b.*, a.AuthorName, g.GenreName 
                                        FROM Books b 
                                        INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                                        INNER JOIN Genres g ON b.GenreId = g.GenreId 
                                        WHERE b.BookId NOT IN (
                                            SELECT BookId FROM ReadHistory WHERE UserId = {userId}
                                        ) AND b.GenreId != {genreId}
                                        ORDER BY b.Rating DESC, b.Popularity DESC";
                var dtPopular = DatabaseHelper.ExecuteQuery(popularQuery); // Выполняем второй запрос
                dt.Merge(dtPopular);                             // Merge — объединяем две таблицы в одну
            }

            foreach (DataRow row in dt.Rows)                     // Перебираем все строки объединённой таблицы
            {
                books.Add(_bookService.MapBook(row));            // DataRow → Book, добавляем в список
            }
            return books;
        }

        public List<Book> GetSimilarUsersBooks(int userId)       // Книги от пользователей с похожими интересами
        {
            int? favoriteGenreId = GetFavoriteGenre(userId);    // Находим любимый жанр
            if (!favoriteGenreId.HasValue)                       // Если жанр не найден
                return _bookService.GetPopularBooks(5);          // Возвращаем просто популярные

            var books = new List<Book>();
            // TOP 5 — максимум 5 книг
            // WHERE b.GenreId = {favoriteGenreId} — книги любимого жанра
            // NOT IN (SELECT ... FROM ReadHistory) — исключаем прочитанные
            // NOT IN (SELECT ... FROM Loans WHERE Status = 'Выдана') — исключаем взятые сейчас
            // ORDER BY b.Popularity DESC — самые популярные сверху
            string query = $@"SELECT TOP 5 b.*, a.AuthorName, g.GenreName 
                             FROM Books b 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             INNER JOIN Genres g ON b.GenreId = g.GenreId 
                             WHERE b.GenreId = {favoriteGenreId.Value}
                             AND b.BookId NOT IN (
                                 SELECT BookId FROM ReadHistory WHERE UserId = {userId}
                             )
                             AND b.BookId NOT IN (
                                 SELECT BookId FROM Loans WHERE UserId = {userId} AND Status = N'Выдана'
                             )
                             ORDER BY b.Popularity DESC";

            var dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                books.Add(_bookService.MapBook(row));
            }
            return books;
        }

        public List<Book> GetTrendingBooks()                     // Трендовые книги за последние 30 дней
        {
            var books = new List<Book>();
            // TOP 10 — максимум 10 книг
            // COUNT(l.LoanId) — подсчёт количества выдач
            // LEFT JOIN Loans — даже если книгу не брали (тогда COUNT = 0)
            // DATEADD(DAY, -30, GETDATE()) — фильтр: только за последние 30 дней
            // GROUP BY — группировка по всем колонкам для корректного COUNT
            // ORDER BY LoanCount DESC — больше выдач сверху
            string query = @"SELECT TOP 10 b.*, a.AuthorName, g.GenreName, COUNT(l.LoanId) as LoanCount
                            FROM Books b 
                            INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                            INNER JOIN Genres g ON b.GenreId = g.GenreId 
                            LEFT JOIN Loans l ON b.BookId = l.BookId 
                            WHERE l.LoanDate >= DATEADD(DAY, -30, GETDATE())
                            GROUP BY b.BookId, b.Title, a.AuthorName, g.GenreName, 
                                     b.PublicationYear, b.Language, b.Annotation, 
                                     b.Rating, b.Popularity, b.IsNew, b.IsHit, b.IsAvailable, 
                                     b.DateAdded, b.AuthorId, b.GenreId, b.CoverImage,
                                     b.TotalCopies, b.AvailableCopies, b.BookType, b.PdfContent
                            ORDER BY LoanCount DESC";

            var dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                books.Add(_bookService.MapBook(row));
            }
            return books;
        }
    }
}