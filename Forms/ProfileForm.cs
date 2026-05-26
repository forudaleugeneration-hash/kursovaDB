using System.Data;                             // DataTable, DataRow для результатов SQL-запросов
using LibraryApp.Database;                     // DatabaseHelper — выполнение SQL-запросов к БД
using LibraryApp.Models;                       // User — модель данных пользователя
using LibraryApp.Services;                     // UserService — сервис для операций пользователя

namespace LibraryApp.Forms
{
    public partial class ProfileForm : Form     // partial — класс разделён на логику и дизайн; Form — окно Windows
    {
        private User? _currentUser;              // Текущий пользователь; ? — может быть null (если форма открыта без параметров)
        private readonly UserService _userService; // Сервис для закладок, возврата книг, отзывов

        public ProfileForm()                     // Пустой конструктор (для совместимости с дизайнером)
        {
            InitializeComponent();               // Создаёт все элементы формы (метод из Designer.cs)
            _userService = new UserService();    // Создаём сервис пользователей
        }

        public ProfileForm(User user) : this()   // Конструктор с пользователем; : this() — сначала вызывает пустой конструктор
        {
            _currentUser = user;                 // Сохраняем переданного пользователя
            SetupEvents();                       // Подписываемся на клики кнопок
            LoadAllData();                       // Загружаем все данные профиля
        }

        private void SetupEvents()               // Подписка на события кнопок и таблиц
        {
            btnReturnBook.Click += BtnReturnBook_Click;           // Кнопка «Вернуть»
            btnCancelReservation.Click += BtnCancelReservation_Click; // Кнопка «Отменить бронь»
            btnRemoveBookmark.Click += BtnRemoveBookmark_Click;   // Кнопка «Убрать» (из закладок)
            btnClearHistory.Click += BtnClearHistory_Click;      // Кнопка «Очистить историю»
            dataGridViewLoanedBooks.SelectionChanged += DataGridViewLoanedBooks_SelectionChanged; // Выбор строки в таблице книг
        }

        private void LoadAllData()               // Загрузка всех секций профиля
        {
            LoadUserInfo();                      // Информация о пользователе (имя, email, дата)
            LoadLoanedBooks();                   // Список взятых и забронированных книг
            LoadBookmarks();                     // Список закладок
            LoadReadHistory();                   // История прочитанных книг
        }

        private void LoadUserInfo()              // Отображение информации о пользователе
        {
            if (_currentUser == null) return;    // Защита: если пользователь не передан — выходим
            lblUserName.Text = _currentUser.FullName; // Полное имя пользователя
            lblEmail.Text = $"Email: {_currentUser.Email}"; // Email
            lblRegistrationDate.Text = $"Дата регистрации: {_currentUser.RegistrationDate:dd.MM.yyyy}"; // Дата регистрации
        }

        private void LoadLoanedBooks()           // Загрузка списка взятых/забронированных книг
        {
            if (_currentUser == null) return;

            string query = $@"SELECT l.LoanDate, l.DueDate, b.Title, a.AuthorName, l.Status, l.ReservationCode
                             FROM Loans l 
                             INNER JOIN Books b ON l.BookId = b.BookId 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             WHERE l.UserId = {_currentUser.UserId} 
                             AND l.Status IN (N'Выдана', N'Забронирована') 
                             ORDER BY l.LoanDate DESC"; // Только активные займы, новые сверху

            DataTable dt = DatabaseHelper.ExecuteQuery(query); // Выполняем SQL-запрос
            dataGridViewLoanedBooks.Rows.Clear(); // Очищаем старые строки

            foreach (DataRow row in dt.Rows)     // Перебираем строки результата
            {
                dataGridViewLoanedBooks.Rows.Add( // Добавляем строку в таблицу (колонки из Designer.cs)
                    Convert.ToDateTime(row["LoanDate"]).ToString("dd.MM.yyyy"),  // [0] colLoanDate — Дата выдачи
                    Convert.ToDateTime(row["DueDate"]).ToString("dd.MM.yyyy"),    // [1] colLoanDueDate — Вернуть до
                    row["Title"]?.ToString() ?? "",                               // [2] colLoanTitle — Книга
                    row["AuthorName"]?.ToString() ?? "",                          // [3] colLoanAuthor — Автор
                    row["Status"]?.ToString() ?? "",                              // [4] colLoanStatus — Статус
                    row["ReservationCode"]?.ToString() ?? ""                      // [5] colLoanCode — Код брони
                );
            }

            UpdateButtons();                     // Обновляем состояние кнопок
        }

        private void UpdateButtons()             // Обновление кнопок в зависимости от выбранной строки
        {
            btnReturnBook.Enabled = false;       // По умолчанию кнопки неактивны
            btnReturnBook.Text = "Вернуть";
            btnCancelReservation.Enabled = false;
            btnCancelReservation.Visible = false; // Кнопка отмены брони скрыта

            if (dataGridViewLoanedBooks.SelectedRows.Count == 0) return; // Ничего не выбрано — выходим

            var row = dataGridViewLoanedBooks.SelectedRows[0]; // Первая выделенная строка
            string status = row.Cells[4].Value?.ToString() ?? ""; // [4] Статус («Выдана» или «Забронирована»)

            if (status == "Забронирована")       // Если книга только забронирована (не выдана)
            {
                btnCancelReservation.Visible = true; // Показываем кнопку отмены брони
                btnCancelReservation.Enabled = true; // Делаем её активной
            }
        }

        private void DataGridViewLoanedBooks_SelectionChanged(object? sender, EventArgs e) // При выборе строки
        {
            UpdateButtons();                     // Обновляем кнопки
        }

        private void BtnReturnBook_Click(object? sender, EventArgs e) // Кнопка «Вернуть» — заглушка
        {
            MessageBox.Show("Печатные книги возвращайте библиотекарю.", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information); // Печатные книги возвращаются только через библиотекаря
        }

        private void BtnCancelReservation_Click(object? sender, EventArgs e) // Отмена бронирования
        {
            if (_currentUser == null) return;
            if (dataGridViewLoanedBooks.SelectedRows.Count == 0)
            { MessageBox.Show("Выберите книгу."); return; }

            var row = dataGridViewLoanedBooks.SelectedRows[0];
            string status = row.Cells[4].Value?.ToString() ?? ""; // [4] Статус
            string title = row.Cells[2].Value?.ToString() ?? "";  // [2] Название книги

            if (status != "Забронирована")       // Защита: отменить можно только бронь
            { MessageBox.Show("Можно отменить только бронь."); return; }

            if (MessageBox.Show($"Отменить бронь «{title}»?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            string cancelQuery = $@"UPDATE Loans SET Status = N'Отменена', ReturnDate = GETDATE() 
                                   WHERE UserId = {_currentUser.UserId} 
                                   AND BookId = (SELECT BookId FROM Books WHERE Title = N'{title.Replace("'", "''")}')
                                   AND Status = N'Забронирована'"; // Меняем статус займа на «Отменена»
            DatabaseHelper.ExecuteNonQuery(cancelQuery); // Выполняем SQL

            string deletePickup = $@"DELETE FROM BookPickups 
                                    WHERE ReservationCode = '{row.Cells[5].Value}'
                                    AND Status = N'Ожидает'"; // Удаляем запись из таблицы выдач
            DatabaseHelper.ExecuteNonQuery(deletePickup);

            string updateBook = $@"UPDATE Books SET AvailableCopies = AvailableCopies + 1, IsAvailable = 1 
                                  WHERE Title = N'{title.Replace("'", "''")}'"; // Возвращаем копию в доступные
            DatabaseHelper.ExecuteNonQuery(updateBook);

            MessageBox.Show("Бронь отменена!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadAllData();                       // Обновляем все данные профиля
        }

        private void LoadBookmarks()             // Загрузка списка закладок
        {
            if (_currentUser == null) return;

            string query = $@"SELECT b.Title, a.AuthorName, g.GenreName, b.Rating, bm.DateAdded
                             FROM Bookmarks bm 
                             INNER JOIN Books b ON bm.BookId = b.BookId 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             INNER JOIN Genres g ON b.GenreId = g.GenreId 
                             WHERE bm.UserId = {_currentUser.UserId} 
                             ORDER BY bm.DateAdded DESC"; // Закладки: новые сверху

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            dataGridViewBookmarks.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                dataGridViewBookmarks.Rows.Add(
                    row["Title"]?.ToString() ?? "",                               // [0] colBookmarkTitle — Книга
                    row["AuthorName"]?.ToString() ?? "",                          // [1] colBookmarkAuthor — Автор
                    row["GenreName"]?.ToString() ?? "",                           // [2] colBookmarkGenre — Жанр
                    $"{Convert.ToDecimal(row["Rating"]):F1}",                     // [3] colBookmarkRating — Рейтинг
                    Convert.ToDateTime(row["DateAdded"]).ToString("dd.MM.yyyy")   // [4] colBookmarkDate — Добавлено
                );
            }
        }

        private void BtnRemoveBookmark_Click(object? sender, EventArgs e) // Удаление из закладок
        {
            if (_currentUser == null) return;
            if (dataGridViewBookmarks.SelectedRows.Count == 0)
            { MessageBox.Show("Выберите книгу."); return; }

            string title = dataGridViewBookmarks.SelectedRows[0].Cells[0].Value?.ToString() ?? ""; // [0] Название книги

            if (MessageBox.Show($"Удалить «{title}» из закладок?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            string query = $@"DELETE FROM Bookmarks 
                             WHERE UserId = {_currentUser.UserId} 
                             AND BookId = (SELECT BookId FROM Books WHERE Title = N'{title.Replace("'", "''")}')"; // Удаляем закладку по названию
            DatabaseHelper.ExecuteNonQuery(query);

            MessageBox.Show("Удалено из закладок.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadBookmarks();                     // Обновляем список закладок
        }

        private void LoadReadHistory()           // Загрузка истории прочитанных книг
        {
            if (_currentUser == null) return;

            string query = $@"SELECT rh.ReadDate, b.Title, a.AuthorName, b.Rating 
                             FROM ReadHistory rh 
                             INNER JOIN Books b ON rh.BookId = b.BookId 
                             INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                             WHERE rh.UserId = {_currentUser.UserId} 
                             ORDER BY rh.ReadDate DESC"; // История: новые сверху

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            dataGridViewReadHistory.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                dataGridViewReadHistory.Rows.Add(
                    Convert.ToDateTime(row["ReadDate"]).ToString("dd.MM.yyyy"),   // [0] colHistoryDate — Дата прочтения
                    row["Title"]?.ToString() ?? "",                               // [1] colHistoryTitle — Книга
                    row["AuthorName"]?.ToString() ?? "",                          // [2] colHistoryAuthor — Автор
                    $"{Convert.ToDecimal(row["Rating"]):F1}"                      // [3] colHistoryRating — Рейтинг
                );
            }
        }

        private void BtnClearHistory_Click(object? sender, EventArgs e) // Очистка всей истории
        {
            if (_currentUser == null) return;

            if (dataGridViewReadHistory.Rows.Count == 0) // История уже пуста
            { MessageBox.Show("История пуста."); return; }

            if (MessageBox.Show("Очистить всю историю прочитанных книг?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            string query = $"DELETE FROM ReadHistory WHERE UserId = {_currentUser.UserId}"; // Удаляем все записи истории
            DatabaseHelper.ExecuteNonQuery(query);

            MessageBox.Show("История очищена!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadReadHistory();                   // Обновляем таблицу (будет пустой)
        }
    }
}