using System.Data;                             // DataTable, DataRow — для работы с результатами SQL-запросов
using LibraryApp.Database;                     // DatabaseHelper — выполнение запросов к БД
using LibraryApp.Models;                       // Book — модель данных книги

namespace LibraryApp.Services
{
    public class BookService                   // Сервис для операций с книгами (получение, рейтинг, популярность)
    {
        public List<Book> GetPopularBooks(int limit = 10) // Получить популярные книги; limit=10 — параметр по умолчанию
        {
            var books = new List<Book>();        // Создаём пустой список для результата
            string query = $@"SELECT TOP {limit} b.*, a.AuthorName, g.GenreName  // TOP {limit} — только N первых записей
                             FROM Books b 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId     // JOIN: добавляем имя автора
                             INNER JOIN Genres g ON b.GenreId = g.GenreId        // JOIN: добавляем название жанра
                             WHERE b.IsHit = 1 OR b.Popularity > 50              // Хиты ИЛИ популярные (счётчик > 50)
                             ORDER BY b.Popularity DESC, b.Rating DESC";         // Сортировка: популярные → рейтинг
            var dt = DatabaseHelper.ExecuteQuery(query); // Выполняем SQL-запрос, получаем DataTable
            foreach (DataRow row in dt.Rows)             // Перебираем строки результата
                books.Add(MapBook(row));                  // Преобразуем DataRow в объект Book и добавляем в список
            return books;                                 // Возвращаем готовый список
        }

        public List<Book> GetNewBooks(int limit = 10)    // Получить новинки (IsNew = 1)
        {
            var books = new List<Book>();
            string query = $@"SELECT TOP {limit} b.*, a.AuthorName, g.GenreName 
                             FROM Books b 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             INNER JOIN Genres g ON b.GenreId = g.GenreId 
                             WHERE b.IsNew = 1                                  // Только новинки
                             ORDER BY b.DateAdded DESC";                        // Сортировка: новые сверху
            var dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows) books.Add(MapBook(row));
            return books;
        }

        public List<Book> GetRecommendedBooks(int userId) // Персональные рекомендации по любимому жанру
        {
            var books = new List<Book>();
            string query = $@"SELECT TOP 5 b.*, a.AuthorName, g.GenreName 
                             FROM Books b 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             INNER JOIN Genres g ON b.GenreId = g.GenreId 
                             WHERE b.GenreId IN (                               -- Жанр, который пользователь читал
                                 SELECT DISTINCT b2.GenreId FROM ReadHistory rh -- Подзапрос: жанры из истории чтения
                                 INNER JOIN Books b2 ON rh.BookId = b2.BookId 
                                 WHERE rh.UserId = {userId}                     -- Для конкретного пользователя
                             ) AND b.BookId NOT IN (                            -- Исключаем уже прочитанные
                                 SELECT BookId FROM ReadHistory WHERE UserId = {userId}
                             )
                             ORDER BY b.Rating DESC";                           // Сортировка: высокий рейтинг сверху
            var dt = DatabaseHelper.ExecuteQuery(query);
            if (dt.Rows.Count < 5)                                               // Если рекомендаций меньше 5
            {
                query = $@"SELECT TOP {5 - dt.Rows.Count} b.*, a.AuthorName, g.GenreName -- Добираем популярными
                          FROM Books b 
                          INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                          INNER JOIN Genres g ON b.GenreId = g.GenreId 
                          WHERE b.BookId NOT IN (
                              SELECT BookId FROM ReadHistory WHERE UserId = {userId}
                          ) ORDER BY b.Rating DESC";
                var dtPopular = DatabaseHelper.ExecuteQuery(query); // Выполняем второй запрос
                dt.Merge(dtPopular);                                 // Merge — объединяем две таблицы в одну
            }
            foreach (DataRow row in dt.Rows) books.Add(MapBook(row));
            return books;
        }

        public Book? GetBookById(int bookId)     // Получить ОДНУ книгу по ID; ? — может вернуть null если не найдена
        {
            string query = $@"SELECT b.*, a.AuthorName, g.GenreName 
                             FROM Books b 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             INNER JOIN Genres g ON b.GenreId = g.GenreId 
                             WHERE b.BookId = {bookId}";           // Точный поиск по ID
            var dt = DatabaseHelper.ExecuteQuery(query);
            if (dt.Rows.Count > 0)                                   // Если нашли (есть хотя бы одна строка)
                return MapBook(dt.Rows[0]);                          // Преобразуем первую строку в Book и возвращаем
            return null;                                             // Не нашли — возвращаем null
        }

        public void UpdateBookRating(int bookId)  // Пересчитать средний рейтинг книги после нового отзыва
        {
            string query = $@"UPDATE Books SET Rating = (
                SELECT ISNULL(AVG(CAST(Rating AS DECIMAL(3,2))), 0) -- ISNULL — если нет отзывов, вернуть 0
                FROM Reviews WHERE BookId = {bookId}                 -- AVG — среднее арифметическое; CAST — преобразовать в DECIMAL
            ) WHERE BookId = {bookId}";
            DatabaseHelper.ExecuteNonQuery(query); // Выполняем UPDATE (не возвращает строки)
        }

        public void IncrementPopularity(int bookId) // Увеличить счётчик популярности на 1
        {
            DatabaseHelper.ExecuteNonQuery(
                $"UPDATE Books SET Popularity = Popularity + 1 WHERE BookId = {bookId}"); // +1 к текущему значению
        }

        public Book MapBook(DataRow row)         // Преобразовать строку DataTable в объект Book
        {
            return new Book                      // Создаём и возвращаем новый объект Book
            {
                BookId = Convert.ToInt32(row["BookId"]),             // Convert.ToInt32 — object → int
                Title = row["Title"]?.ToString() ?? string.Empty,    // ?. — если null, не вызывать ToString(); ?? — заменить на ""
                AuthorId = Convert.ToInt32(row["AuthorId"]),
                AuthorName = row["AuthorName"]?.ToString() ?? string.Empty, // Заполняется через JOIN с Authors
                GenreId = Convert.ToInt32(row["GenreId"]),
                GenreName = row["GenreName"]?.ToString() ?? string.Empty,   // Заполняется через JOIN с Genres
                PublicationYear = Convert.ToInt32(row["PublicationYear"]),
                Language = row["Language"]?.ToString() ?? "Русский",
                Annotation = row["Annotation"]?.ToString() ?? string.Empty,
                CoverImage = row.Table.Columns.Contains("CoverImage")       // Проверка: есть ли колонка CoverImage
                    ? row["CoverImage"] as byte[]                          // Есть → приводим object к byte[]
                    : null,                                                 // Нет → null
                PdfContent = row.Table.Columns.Contains("PdfContent")
                    ? row["PdfContent"] as byte[]
                    : null,
                BookType = row.Table.Columns.Contains("BookType")
                    ? row["BookType"]?.ToString() ?? "Печатная"
                    : "Печатная",
                TotalCopies = row.Table.Columns.Contains("TotalCopies")
                    ? Convert.ToInt32(row["TotalCopies"]) : 1,
                AvailableCopies = row.Table.Columns.Contains("AvailableCopies")
                    ? Convert.ToInt32(row["AvailableCopies"]) : 1,
                Rating = Convert.ToDecimal(row["Rating"]),           // Convert.ToDecimal — object → decimal
                Popularity = Convert.ToInt32(row["Popularity"]),
                IsNew = Convert.ToBoolean(row["IsNew"]),             // Convert.ToBoolean — object → bool
                IsHit = Convert.ToBoolean(row["IsHit"]),
                IsAvailable = Convert.ToBoolean(row["IsAvailable"]),
                DateAdded = Convert.ToDateTime(row["DateAdded"])     // Convert.ToDateTime — object → DateTime
            };
        }
    }
}