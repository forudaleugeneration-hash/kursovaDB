using System.Data;                             // DataTable, DataRow — работа с результатами SQL-запросов
using Microsoft.Data.SqlClient;                // SqlCommand, SqlParameter — для параметризованных запросов (обложки, PDF)
using LibraryApp.Database;                     // DatabaseHelper — выполнение SQL-запросов к базе данных
using LibraryApp.Models;                       // UserWithRole, BookManageModel, BookPickup, AdminLog — модели данных

namespace LibraryApp.Services
{
    public class AdminService                  // Сервис для ВСЕХ административных операций (CRUD + выдача)
    {

        // ПОЛЬЗОВАТЕЛИ


        public List<UserWithRole> GetAllUsers()  // Получить список всех пользователей с ролями и статистикой
        {
            var users = new List<UserWithRole>(); // Создаём пустой список для результата
            string query = @"SELECT u.*, r.RoleName,                                    // Все колонки Users + название роли
                            (SELECT COUNT(*) FROM Loans WHERE UserId = u.UserId) as LoansCount,    // Подзапрос: сколько займов
                            (SELECT COUNT(*) FROM Reviews WHERE UserId = u.UserId) as ReviewsCount // Подзапрос: сколько отзывов
                            FROM Users u 
                            INNER JOIN Roles r ON u.RoleId = r.RoleId                   // JOIN: добавляем название роли
                            ORDER BY u.RegistrationDate DESC";                           // Сортировка: новые сверху
            var dt = DatabaseHelper.ExecuteQuery(query); // Выполняем SQL-запрос, получаем DataTable
            foreach (DataRow row in dt.Rows)             // Перебираем строки результата
            {
                users.Add(new UserWithRole               // Создаём объект UserWithRole из строки таблицы
                {
                    UserId = Convert.ToInt32(row["UserId"]),              // Convert.ToInt32 — object → int
                    Username = row["Username"]?.ToString() ?? string.Empty, // ?. — если null, пропустить; ?? — заменить на ""
                    Email = row["Email"]?.ToString() ?? string.Empty,
                    FullName = row["FullName"]?.ToString() ?? string.Empty,
                    RegistrationDate = Convert.ToDateTime(row["RegistrationDate"]), // Convert.ToDateTime — object → DateTime
                    IsActive = Convert.ToBoolean(row["IsActive"]),       // Convert.ToBoolean — object → bool
                    RoleName = row["RoleName"]?.ToString() ?? string.Empty, // Название роли из JOIN
                    LoansCount = Convert.ToInt32(row["LoansCount"]),     // Количество займов из подзапроса
                    ReviewsCount = Convert.ToInt32(row["ReviewsCount"])  // Количество отзывов из подзапроса
                });
            }
            return users;                        // Возвращаем готовый список
        }

        public void UpdateUserRole(int userId, int roleId) // Изменить роль пользователя (1=Admin, 2=Librarian, 3=User)
        {
            DatabaseHelper.ExecuteNonQuery(      // ExecuteNonQuery — для INSERT/UPDATE/DELETE (не возвращает строки)
                $"UPDATE Users SET RoleId = {roleId} WHERE UserId = {userId}"); // SQL: обновить роль у конкретного пользователя
        }

        public void ToggleUserActive(int userId, bool isActive) // Переключить активность (заблокировать/разблокировать)
        {
            DatabaseHelper.ExecuteNonQuery(
                $"UPDATE Users SET IsActive = {(isActive ? 1 : 0)} WHERE UserId = {userId}"); // Тернарный оператор: true→1, false→0
        }

        public void DeleteUser(int userId)       // Полное удаление пользователя и всех его данных
        {
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM Reviews WHERE UserId = {userId}");      // 1. Удаляем отзывы
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM Bookmarks WHERE UserId = {userId}");    // 2. Удаляем закладки
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM ReadHistory WHERE UserId = {userId}");  // 3. Удаляем историю чтения
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM BookPickups WHERE UserId = {userId}"); // 4. Удаляем записи выдачи
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM Loans WHERE UserId = {userId}");        // 5. Удаляем займы
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM AdminLogs WHERE AdminId = {userId}");   // 6. Удаляем логи действий
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM Users WHERE UserId = {userId} AND RoleId != 1"); // 7. Удаляем самого, но не админа, админа удалить нельзя
        }


        // КНИГИ


        public List<BookManageModel> GetAllBooksForManagement() // Получить список книг с доп. информацией для админ-панели
        {
            var books = new List<BookManageModel>();
            string query = @"SELECT b.*, a.AuthorName, g.GenreName,                     // Все колонки Books + автор + жанр
                            (SELECT COUNT(*) FROM Loans WHERE BookId = b.BookId) as LoansCount,   // Сколько раз брали
                            (SELECT COUNT(*) FROM Reviews WHERE BookId = b.BookId) as ReviewsCount // Сколько отзывов
                            FROM Books b 
                            INNER JOIN Authors a ON b.AuthorId = a.AuthorId             // JOIN: имя автора
                            INNER JOIN Genres g ON b.GenreId = g.GenreId                 // JOIN: название жанра
                            ORDER BY b.BookId";                                          // Сортировка по ID
            var dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                books.Add(new BookManageModel
                {
                    BookId = Convert.ToInt32(row["BookId"]),
                    Title = row["Title"]?.ToString() ?? string.Empty,
                    AuthorId = Convert.ToInt32(row["AuthorId"]),
                    AuthorName = row["AuthorName"]?.ToString() ?? string.Empty,          // Из JOIN с Authors
                    GenreId = Convert.ToInt32(row["GenreId"]),
                    GenreName = row["GenreName"]?.ToString() ?? string.Empty,            // Из JOIN с Genres
                    PublicationYear = Convert.ToInt32(row["PublicationYear"]),
                    Language = row["Language"]?.ToString() ?? "Русский",
                    Annotation = row["Annotation"]?.ToString() ?? string.Empty,
                    Rating = Convert.ToDecimal(row["Rating"]),                           // decimal — для дробного рейтинга
                    Popularity = Convert.ToInt32(row["Popularity"]),
                    IsAvailable = Convert.ToBoolean(row["IsAvailable"]),
                    IsNew = Convert.ToBoolean(row["IsNew"]),
                    IsHit = Convert.ToBoolean(row["IsHit"]),
                    DateAdded = Convert.ToDateTime(row["DateAdded"]),
                    BookType = row.Table.Columns.Contains("BookType")                    // Проверка: есть ли колонка BookType в таблице
                        ? row["BookType"]?.ToString() ?? "Печатная"                     // Есть → берём значение
                        : "Печатная",                                                    // Нет → по умолчанию
                    TotalCopies = row.Table.Columns.Contains("TotalCopies")              // Аналогичная проверка для TotalCopies
                        ? Convert.ToInt32(row["TotalCopies"]) : 1,
                    AvailableCopies = row.Table.Columns.Contains("AvailableCopies")
                        ? Convert.ToInt32(row["AvailableCopies"]) : 1,
                    LoansCount = Convert.ToInt32(row["LoansCount"]),                     // Из подзапроса
                    ReviewsCount = Convert.ToInt32(row["ReviewsCount"])                  // Из подзапроса
                });
            }
            return books;
        }

        public void AddBook(string title, int authorId, int genreId, int year,
            string language, string annotation, int totalCopies = 1) // Добавить новую книгу; totalCopies=1 — параметр по умолчанию
        {
            string query = $@"INSERT INTO Books (Title, AuthorId, GenreId, PublicationYear, Language, Annotation, TotalCopies, AvailableCopies) 
                             VALUES (N'{title.Replace("'", "''")}', {authorId}, {genreId}, {year}, 
                                     N'{language}', N'{annotation.Replace("'", "''")}', {totalCopies}, {totalCopies})";
            // N'...' — Unicode (NVARCHAR); Replace("'","''") — экранирование кавычек для SQL
            // AvailableCopies = TotalCopies (при создании все копии доступны)
            DatabaseHelper.ExecuteNonQuery(query);
        }

        public void UpdateBook(int bookId, string title, int authorId, int genreId, int year,
            string language, string annotation, bool isNew, bool isHit,
            string bookType = "Печатная", int totalCopies = 1) // Обновить существующую книгу
        {
            string query = $@"UPDATE Books SET 
                             Title = N'{title.Replace("'", "''")}',
                             AuthorId = {authorId}, GenreId = {genreId},
                             PublicationYear = {year}, Language = N'{language}',
                             Annotation = N'{annotation.Replace("'", "''")}',
                             IsNew = {(isNew ? 1 : 0)}, IsHit = {(isHit ? 1 : 0)},  // bool → 1/0 для SQL
                             BookType = N'{bookType}', TotalCopies = {totalCopies}
                             WHERE BookId = {bookId}";                                // Обновляем только конкретную книгу
            DatabaseHelper.ExecuteNonQuery(query);
        }

        public void DeleteBook(int bookId)       // Удалить книгу и все связанные данные
        {
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM Reviews WHERE BookId = {bookId}");       // 1. Отзывы о книге
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM Bookmarks WHERE BookId = {bookId}");     // 2. Закладки
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM ReadHistory WHERE BookId = {bookId}");   // 3. История чтения
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM BookPickups WHERE BookId = {bookId}");  // 4. Записи выдачи
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM Loans WHERE BookId = {bookId}");         // 5. Займы
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM Books WHERE BookId = {bookId}");         // 6. Саму книгу
        }


        // АВТОРЫ


        public void AddAuthor(string authorName) // Добавить нового автора
        {
            DatabaseHelper.ExecuteNonQuery(
                $"INSERT INTO Authors (AuthorName) VALUES (N'{authorName.Replace("'", "''")}')");
        }

        public void UpdateAuthor(int authorId, string authorName) // Переименовать автора
        {
            DatabaseHelper.ExecuteNonQuery(
                $"UPDATE Authors SET AuthorName = N'{authorName.Replace("'", "''")}' WHERE AuthorId = {authorId}");
        }

        public bool DeleteAuthor(int authorId)   // Удалить автора (если у него нет книг); возвращает true если удалён
        {
            var result = DatabaseHelper.ExecuteScalar(             // ExecuteScalar — возвращает одно значение (COUNT)
                $"SELECT COUNT(*) FROM Books WHERE AuthorId = {authorId}"); // Сколько книг у автора
            if (result != null && Convert.ToInt32(result) > 0)    // Если есть книги — не удаляем
                return false;                                      // Возвращаем false (не удалось)
            DatabaseHelper.ExecuteNonQuery(
                $"DELETE FROM Authors WHERE AuthorId = {authorId}"); // Удаляем автора
            return true;                                           // Возвращаем true (успешно)
        }

        public DataTable GetAuthors()            // Получить список всех авторов (для выпадающих списков)
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM Authors ORDER BY AuthorName");
        }

        public DataTable GetAuthorsWithBookCount() // Получить авторов с количеством книг (для админ-панели)
        {
            return DatabaseHelper.ExecuteQuery(
                @"SELECT a.AuthorId, a.AuthorName, COUNT(b.BookId) as BookCount         // COUNT — подсчёт книг
                  FROM Authors a LEFT JOIN Books b ON a.AuthorId = b.AuthorId            // LEFT JOIN — даже если книг нет
                  GROUP BY a.AuthorId, a.AuthorName ORDER BY a.AuthorName");            // GROUP BY — для COUNT
        }


        // ЖАНРЫ


        public void AddGenre(string genreName)   // Добавить новый жанр
        {
            DatabaseHelper.ExecuteNonQuery(
                $"INSERT INTO Genres (GenreName) VALUES (N'{genreName.Replace("'", "''")}')");
        }

        public void UpdateGenre(int genreId, string genreName) // Переименовать жанр
        {
            DatabaseHelper.ExecuteNonQuery(
                $"UPDATE Genres SET GenreName = N'{genreName.Replace("'", "''")}' WHERE GenreId = {genreId}");
        }

        public bool DeleteGenre(int genreId)     // Удалить жанр (если к нему не привязаны книги)
        {
            var result = DatabaseHelper.ExecuteScalar(
                $"SELECT COUNT(*) FROM Books WHERE GenreId = {genreId}");
            if (result != null && Convert.ToInt32(result) > 0) return false; // Есть книги — не удаляем
            DatabaseHelper.ExecuteNonQuery($"DELETE FROM Genres WHERE GenreId = {genreId}");
            return true;
        }

        public DataTable GetGenres()             // Получить список всех жанров
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM Genres ORDER BY GenreName");
        }

        public DataTable GetGenresWithBookCount() // Получить жанры с количеством книг
        {
            return DatabaseHelper.ExecuteQuery(
                @"SELECT g.GenreId, g.GenreName, COUNT(b.BookId) as BookCount
                  FROM Genres g LEFT JOIN Books b ON g.GenreId = b.GenreId 
                  GROUP BY g.GenreId, g.GenreName ORDER BY g.GenreName");
        }


        // ОБЛОЖКИ (используют параметризованные запросы для BLOB-данных)


        public void UpdateBookCover(int bookId, byte[] coverImage) // Сохранить/обновить обложку книги
        {
            string query = "UPDATE Books SET CoverImage = @CoverImage WHERE BookId = @BookId"; // @Параметры — защита от SQL-инъекций
            using var connection = DatabaseHelper.GetConnection();  // using — автоматически закроет соединение
            using var command = new SqlCommand(query, connection);  // SqlCommand — параметризованная SQL-команда
            command.Parameters.AddWithValue("@CoverImage", coverImage); // Подставляем массив байтов в @CoverImage
            command.Parameters.AddWithValue("@BookId", bookId);     // Подставляем ID книги в @BookId
            command.ExecuteNonQuery();                               // Выполняем UPDATE
        }

        public byte[]? GetBookCover(int bookId)  // Получить обложку книги (массив байтов или null)
        {
            var dt = DatabaseHelper.ExecuteQuery(
                $"SELECT CoverImage FROM Books WHERE BookId = {bookId}");
            if (dt.Rows.Count > 0 && dt.Rows[0]["CoverImage"] != DBNull.Value) // Обложка есть и не NULL
                return (byte[])dt.Rows[0]["CoverImage"];         // Приведение object → byte[]
            return null;                                         // Обложки нет
        }

        public void DeleteBookCover(int bookId)  // Удалить обложку (установить NULL)
        {
            DatabaseHelper.ExecuteNonQuery(
                $"UPDATE Books SET CoverImage = NULL WHERE BookId = {bookId}");
        }


        // PDF


        public void UpdateBookPdf(int bookId, byte[] pdfContent) // Сохранить PDF и пометить книгу как «Онлайн»
        {
            string query = "UPDATE Books SET PdfContent = @PdfContent, BookType = N'Онлайн' WHERE BookId = @BookId";
            using var connection = DatabaseHelper.GetConnection();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PdfContent", pdfContent);
            command.Parameters.AddWithValue("@BookId", bookId);
            command.ExecuteNonQuery();
        }

        public byte[]? GetBookPdf(int bookId)    // Получить PDF книги
        {
            var dt = DatabaseHelper.ExecuteQuery($"SELECT PdfContent FROM Books WHERE BookId = {bookId}");
            if (dt.Rows.Count > 0 && dt.Rows[0]["PdfContent"] != DBNull.Value)
                return (byte[])dt.Rows[0]["PdfContent"];
            return null;
        }

        public void DeleteBookPdf(int bookId)    // Удалить PDF и вернуть тип «Печатная»
        {
            DatabaseHelper.ExecuteNonQuery(
                $"UPDATE Books SET PdfContent = NULL, BookType = N'Печатная' WHERE BookId = {bookId}");
        }

        public bool HasPdf(int bookId)           // Проверить, есть ли у книги PDF
        {
            var dt = DatabaseHelper.ExecuteQuery($"SELECT PdfContent FROM Books WHERE BookId = {bookId}");
            return dt.Rows.Count > 0 && dt.Rows[0]["PdfContent"] != DBNull.Value; // true если PDF есть и не NULL
        }


        // БРОНИРОВАНИЕ И ВЫДАЧА КНИГ


        public List<BookPickup> GetPendingPickups() // Получить все записи о выдаче/бронировании
        {
            var pickups = new List<BookPickup>();
            string query = @"SELECT bp.*, l.LoanDate, b.Title as BookTitle, u.Username as UserName,  // Все колонки BookPickups + данные из JOIN
                            lib.FullName as LibrarianName                                            // Имя библиотекаря (отдельный JOIN)
                            FROM BookPickups bp 
                            INNER JOIN Loans l ON bp.LoanId = l.LoanId              // JOIN: дата займа
                            INNER JOIN Books b ON bp.BookId = b.BookId              // JOIN: название книги
                            INNER JOIN Users u ON bp.UserId = u.UserId              // JOIN: логин читателя
                            LEFT JOIN Users lib ON bp.LibrarianId = lib.UserId      // LEFT JOIN: имя библиотекаря (может быть NULL)
                            ORDER BY 
                                CASE bp.Status                                      // CASE — своя сортировка по статусу
                                    WHEN N'Ожидает' THEN 1                          // Ожидает — первыми
                                    WHEN N'Выдана' THEN 2                           // Выдана — вторыми
                                    WHEN N'Возвращена' THEN 3                       // Возвращена — третьими
                                    ELSE 4                                          // Остальное — последними
                                END, 
                                l.LoanDate DESC";                                   // Внутри статуса: новые сверху
            var dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                pickups.Add(new BookPickup
                {
                    PickupId = Convert.ToInt32(row["PickupId"]),
                    LoanId = Convert.ToInt32(row["LoanId"]),
                    BookId = Convert.ToInt32(row["BookId"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    BookTitle = row["BookTitle"]?.ToString() ?? "",                  // Из JOIN с Books
                    UserName = row["UserName"]?.ToString() ?? "",                    // Из JOIN с Users
                    ReservationCode = row["ReservationCode"]?.ToString() ?? "",
                    PickupDate = row["PickupDate"] != DBNull.Value                   // Если дата выдачи не NULL
                        ? Convert.ToDateTime(row["PickupDate"])                      // Преобразуем в DateTime
                        : null,                                                      // Иначе null
                    LoanDate = Convert.ToDateTime(row["LoanDate"]),
                    Status = row["Status"]?.ToString() ?? "Ожидает",
                    LibrarianName = row["LibrarianName"]?.ToString() ?? ""           // Из LEFT JOIN с Users (может быть пусто)
                });
            }
            return pickups;
        }

        public string GenerateReservationCode()  // Сгенерировать случайный 8-значный код (без похожих букв: O,0,I,1)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789"; // 30 символов (без O,0,I,1 чтобы не путать)
            var random = new Random();                               // Генератор случайных чисел
            return new string(Enumerable.Range(0, 8)                 // 8 итераций от 0 до 7
                .Select(_ => chars[random.Next(chars.Length)])       // На каждой: случайный символ из chars
                .ToArray());                                         // Объединяем в строку
        }

        public string CreateReservation(int userId, int bookId) // Создать бронирование: запись в Loans + BookPickups
        {
            var book = new BookService().GetBookById(bookId);        // Получаем книгу для проверки доступности
            if (book == null) return string.Empty;                   // Книга не найдена — выходим

            if (book.BookType == "Печатная" && book.AvailableCopies <= 0) // Печатная и нет доступных копий
                return "NO_COPIES";                                  // Специальный код «нет копий»

            string code = GenerateReservationCode();                 // Генерируем код
            string checkQuery = $"SELECT COUNT(*) FROM Loans WHERE ReservationCode = '{code}'"; // Проверка уникальности
            while (Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery)) > 0) // Пока код уже существует
                code = GenerateReservationCode();                    // Генерируем новый

            var dueDate = DateTime.Now.AddDays(14);                  // Дата возврата: сегодня + 14 дней
            string query = $@"INSERT INTO Loans (UserId, BookId, DueDate, Status, ReservationCode, IsOnline) 
                             VALUES ({userId}, {bookId}, '{dueDate:yyyy-MM-dd}', N'Забронирована', '{code}', 0)";
            DatabaseHelper.ExecuteNonQuery(query);                   // Создаём займ со статусом «Забронирована»

            var result = DatabaseHelper.ExecuteScalar("SELECT MAX(LoanId) FROM Loans"); // ID только что созданного займа
            int loanId = result != null ? Convert.ToInt32(result) : 0;

            query = $@"INSERT INTO BookPickups (LoanId, BookId, UserId, ReservationCode) 
                      VALUES ({loanId}, {bookId}, {userId}, '{code}')";
            DatabaseHelper.ExecuteNonQuery(query);                   // Создаём запись в BookPickups

            if (book.BookType == "Печатная")                         // Для печатных книг уменьшаем счётчик
            {
                DatabaseHelper.ExecuteNonQuery($"UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE BookId = {bookId}");
                DatabaseHelper.ExecuteNonQuery($"UPDATE Books SET IsAvailable = 0 WHERE BookId = {bookId} AND AvailableCopies <= 0");
            }

            return code;                                             // Возвращаем код бронирования
        }

        public bool ConfirmPickup(int pickupId, int librarianId) // Подтвердить выдачу книги библиотекарем
        {
            string query = $@"UPDATE BookPickups 
                             SET Status = N'Выдана', PickupDate = GETDATE(), LibrarianId = {librarianId} 
                             WHERE PickupId = {pickupId} AND Status = N'Ожидает'"; // Только если статус «Ожидает»
            int rows = DatabaseHelper.ExecuteNonQuery(query);       // rows — сколько строк обновлено (0 или 1)
            if (rows > 0)                                            // Если обновили (статус был «Ожидает»)
            {
                query = $@"UPDATE Loans SET Status = N'Выдана' 
                          WHERE LoanId = (SELECT LoanId FROM BookPickups WHERE PickupId = {pickupId})"; // Обновляем статус займа
                DatabaseHelper.ExecuteNonQuery(query);
            }
            return rows > 0;                                         // true — успешно, false — не найден или не тот статус
        }

        public bool ReturnBookByLibrarian(int pickupId, int librarianId) // Принять возврат книги
        {
            string query = $@"UPDATE BookPickups 
                             SET Status = N'Возвращена', LibrarianId = {librarianId} 
                             WHERE PickupId = {pickupId} AND Status = N'Выдана'"; // Только если статус «Выдана»
            int rows = DatabaseHelper.ExecuteNonQuery(query);
            if (rows > 0)
            {
                query = $@"UPDATE Loans SET Status = N'Возвращена', ReturnDate = GETDATE() 
                          WHERE LoanId = (SELECT LoanId FROM BookPickups WHERE PickupId = {pickupId})";
                DatabaseHelper.ExecuteNonQuery(query);                // Обновляем займ

                query = $@"UPDATE Books SET AvailableCopies = AvailableCopies + 1, IsAvailable = 1 
                          WHERE BookId = (SELECT BookId FROM BookPickups WHERE PickupId = {pickupId})";
                DatabaseHelper.ExecuteNonQuery(query);                // Возвращаем копию

                query = $@"INSERT INTO ReadHistory (UserId, BookId)                            // Добавляем в историю
                          SELECT UserId, BookId FROM BookPickups WHERE PickupId = {pickupId}
                          AND NOT EXISTS (SELECT 1 FROM ReadHistory                           // Если ещё нет в истории
                              WHERE UserId = BookPickups.UserId AND BookId = BookPickups.BookId)";
                DatabaseHelper.ExecuteNonQuery(query);
            }
            return rows > 0;
        }

        public bool CancelReservation(int pickupId, int librarianId) // Отменить бронирование
        {
            string getInfoQuery = $@"SELECT LoanId, BookId FROM BookPickups 
                                    WHERE PickupId = {pickupId} AND Status = N'Ожидает'"; // Получаем LoanId и BookId
            var dt = DatabaseHelper.ExecuteQuery(getInfoQuery);
            if (dt.Rows.Count == 0) return false;                    // Не найдено или не тот статус

            int loanId = Convert.ToInt32(dt.Rows[0]["LoanId"]);      // Извлекаем LoanId
            int bookId = Convert.ToInt32(dt.Rows[0]["BookId"]);      // Извлекаем BookId

            string query = $@"UPDATE Loans SET Status = N'Отменена', ReturnDate = GETDATE() 
                             WHERE LoanId = {loanId} AND Status = N'Забронирована'"; // Меняем статус займа
            int rows = DatabaseHelper.ExecuteNonQuery(query);

            if (rows > 0)
            {
                DatabaseHelper.ExecuteNonQuery($"DELETE FROM BookPickups WHERE PickupId = {pickupId}"); // Удаляем запись выдачи
                DatabaseHelper.ExecuteNonQuery($"UPDATE Books SET AvailableCopies = AvailableCopies + 1, IsAvailable = 1 WHERE BookId = {bookId}"); // Возвращаем копию
            }
            return rows > 0;
        }

        public BookPickup? GetPickupByCode(string code) // Найти бронирование по коду (для проверки библиотекарем)
        {
            string query = $@"SELECT bp.*, l.LoanDate, b.Title as BookTitle, u.Username as UserName
                             FROM BookPickups bp 
                             INNER JOIN Loans l ON bp.LoanId = l.LoanId 
                             INNER JOIN Books b ON bp.BookId = b.BookId 
                             INNER JOIN Users u ON bp.UserId = u.UserId 
                             WHERE bp.ReservationCode = '{code}'"; // Ищем точное совпадение кода
            var dt = DatabaseHelper.ExecuteQuery(query);
            if (dt.Rows.Count > 0)                                   // Нашли
            {
                var row = dt.Rows[0];
                return new BookPickup
                {
                    PickupId = Convert.ToInt32(row["PickupId"]),
                    LoanId = Convert.ToInt32(row["LoanId"]),
                    BookId = Convert.ToInt32(row["BookId"]),
                    UserId = Convert.ToInt32(row["UserId"]),
                    BookTitle = row["BookTitle"]?.ToString() ?? "",
                    UserName = row["UserName"]?.ToString() ?? "",
                    ReservationCode = row["ReservationCode"]?.ToString() ?? "",
                    LoanDate = Convert.ToDateTime(row["LoanDate"]),
                    Status = row["Status"]?.ToString() ?? "Ожидает"
                };
            }
            return null;                                             // Не нашли
        }


        // ЛОГИ ДЕЙСТВИЙ


        public void LogAction(int adminId, string action, string details) // Записать действие в лог
        {
            string query = $@"INSERT INTO AdminLogs (AdminId, Action, Details) 
                             VALUES ({adminId}, N'{action.Replace("'", "''")}', N'{details.Replace("'", "''")}')";
            DatabaseHelper.ExecuteNonQuery(query);                   // Добавляем запись в AdminLogs
        }
    }
}