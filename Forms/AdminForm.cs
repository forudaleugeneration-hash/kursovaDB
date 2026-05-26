using System.Data;                             // DataTable, DataRow для работы с результатами SQL-запросов
using LibraryApp.Models;                       // Модели: User, BookManageModel, BookPickup, UserWithRole
using LibraryApp.Services;                     // Сервисы: AdminService (CRUD), BookService (книги)

namespace LibraryApp.Forms
{
    public partial class AdminForm : Form       // partial — класс разделён на логику (.cs) и дизайн (.Designer.cs)
    {
        private readonly User _adminUser;        // Текущий админ/библиотекарь; readonly — задаётся только в конструкторе
        private readonly AdminService _adminService; // Сервис для всех операций с БД (пользователи, книги, авторы, жанры, выдача)
        private readonly BookService _bookService;   // Сервис для операций с книгами (получение по ID, рейтинг)

        public AdminForm(User adminUser)         // Конструктор: adminUser — тот, кто открыл админ-панель
        {
            InitializeComponent();               // Создаёт все вкладки, кнопки, таблицы (метод из Designer.cs)
            _adminUser = adminUser;              // Сохраняем пользователя для логирования и проверки прав
            _adminService = new AdminService();  // Создаём сервис администрирования (все операции с БД)
            _bookService = new BookService();    // Создаём сервис книг (нужен для EditBook)

            SetupUI();                           // Настраиваем верхнюю панель (имя, роль, кнопка «Обновить»)
            SetupEvents();                       // Подписываемся на переключение вкладок и клики всех кнопок

            if (_adminUser.RoleId == 2)          // RoleId == 2 → Библиотекарь (не админ)
                tabControl.TabPages.Remove(tabUsers); // Убираем вкладку «Пользователи» (только для админа)

            LoadUsers();                         // При запуске показываем вкладку «Пользователи» (или «Книги» для библиотекаря)
        }

        private void SetupUI()                   // Настройка верхней панели админ-панели
        {
            var topPanel = new Panel             // Panel — контейнер для группировки элементов
            {
                Dock = DockStyle.Top,            // Прикрепить к верхнему краю, растянуть на всю ширину
                Height = 40,                     // Высота панели в пикселях
                BackColor = Color.FromArgb(44, 62, 80) // Тёмно-синий фон (R=44, G=62, B=80)
            };
            topPanel.Controls.Add(lblAdminInfo); // Добавляем надпись с именем и ролью на панель
            topPanel.Controls.Add(btnRefresh);   // Добавляем кнопку «Обновить» на панель
            Controls.Add(topPanel);              // Добавляем панель на форму (this.Controls)

            lblAdminInfo.Text = $"{_adminUser.RoleName}: {_adminUser.FullName}"; // «Администратор: Иван Иванов»
            lblAdminInfo.Location = new Point(12, 10); // Позиция: 12px слева, 10px сверху
            lblAdminInfo.AutoSize = true;        // Размер надписи подгоняется под текст
        }

        private void SetupEvents()               // Подписка на события: переключение вкладок и клики кнопок
        {
            tabControl.SelectedIndexChanged += (s, e) => // Событие: выбрана другая вкладка
            {
                if (tabControl.SelectedTab == tabUsers) LoadUsers();       // Вкладка «Пользователи» → загрузить список
                else if (tabControl.SelectedTab == tabBooks) LoadBooks();   // Вкладка «Книги» → загрузить список
                else if (tabControl.SelectedTab == tabAuthors) LoadAuthors(); // Вкладка «Авторы»
                else if (tabControl.SelectedTab == tabGenres) LoadGenres();   // Вкладка «Жанры»
                else if (tabControl.SelectedTab == tabPickups) LoadPickups(); // Вкладка «Выдача книг»
            };

            btnRefresh.Click += (s, e) =>         // Кнопка «Обновить» — перезагружает текущую вкладку
            {
                if (tabControl.SelectedTab == tabUsers) LoadUsers();
                else if (tabControl.SelectedTab == tabBooks) LoadBooks();
                else if (tabControl.SelectedTab == tabAuthors) LoadAuthors();
                else if (tabControl.SelectedTab == tabGenres) LoadGenres();
                else if (tabControl.SelectedTab == tabPickups) LoadPickups();
            };

            // Подписка на кнопки вкладки «Пользователи»
            btnEditUser.Click += (s, e) => EditUser();           // «Изменить роль»
            btnToggleActive.Click += (s, e) => ToggleUserActive(); // «Блокировать/Разблокировать»
            btnDeleteUser.Click += (s, e) => DeleteUser();       // «Удалить»

            // Подписка на кнопки вкладки «Книги»
            btnAddBook.Click += (s, e) => AddBook();             // «Добавить книгу»
            btnEditBook.Click += (s, e) => EditBook();           // «Редактировать»
            btnDeleteBook.Click += (s, e) => DeleteBook();       // «Удалить»

            // Подписка на кнопки вкладки «Авторы»
            btnAddAuthor.Click += (s, e) => AddAuthor();         // «Добавить автора»
            btnEditAuthor.Click += (s, e) => EditAuthor();       // «Редактировать»
            btnDeleteAuthor.Click += (s, e) => DeleteAuthor();   // «Удалить»

            // Подписка на кнопки вкладки «Жанры»
            btnAddGenre.Click += (s, e) => AddGenre();           // «Добавить жанр»
            btnEditGenre.Click += (s, e) => EditGenre();         // «Редактировать»
            btnDeleteGenre.Click += (s, e) => DeleteGenre();     // «Удалить»

            // Подписка на кнопки вкладки «Выдача книг»
            btnVerifyCode.Click += (s, e) => VerifyCode();       // «Проверить» код
            btnConfirmPickup.Click += (s, e) => ConfirmPickup(); // «Выдать» книгу
            btnReturnBook.Click += (s, e) => ReturnBookByLibrarian(); // «Возврат» книги
            btnCancelReservationAdmin.Click += (s, e) => CancelReservationByLibrarian(); // «Отменить бронь»
        }

        private void LoadUsers()                 // Загрузка списка пользователей в таблицу
        {
            var users = _adminService.GetAllUsers(); // List<UserWithRole> — все пользователи с ролями и статистикой
            dataGridViewUsers.Rows.Clear();      // Очищаем старые строки перед загрузкой новых

            foreach (var u in users)             // Перебираем всех пользователей
            {
                dataGridViewUsers.Rows.Add(      // Добавляем строку в таблицу (колонки заданы в Designer.cs)
                    u.UserId,                    // [0] colUserId — ID (скрытая колонка)
                    u.Username,                  // [1] colUsername — Логин
                    u.Email,                     // [2] colEmail — Email
                    u.FullName,                  // [3] colFullName — Имя
                    u.RoleName,                  // [4] colRole — Роль
                    u.IsActive ? "Да" : "Нет",   // [5] colActive — Активен (bool → текст)
                    u.RegistrationDate.ToString("dd.MM.yyyy"), // [6] colRegDate — Дата регистрации
                    u.LoansCount,                // [7] colLoansCount — Книг на руках
                    u.ReviewsCount               // [8] colReviewsCount — Отзывов
                );
            }
        }

        private void EditUser()                  // Изменение роли пользователя (повысить/понизить)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0) // Ничего не выбрано
            { MessageBox.Show("Выберите пользователя."); return; }
            var row = dataGridViewUsers.SelectedRows[0]; // Первая выделенная строка
            int userId = Convert.ToInt32(row.Cells[0].Value); // ID из колонки [0] (object → int)
            string username = row.Cells[1].Value?.ToString() ?? ""; // Логин из колонки [1]
            if (userId == _adminUser.UserId)     // Защита от изменения своей роли
            { MessageBox.Show("Нельзя изменить свою роль."); return; }
            var result = MessageBox.Show(        // Диалог: Да = библиотекарь, Нет = пользователь
                $"Изменить роль {username}?\n\nДа - Библиотекарь\nНет - Пользователь",
                "Роль", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) _adminService.UpdateUserRole(userId, 2);      // 2 = Librarian
            else if (result == DialogResult.No) _adminService.UpdateUserRole(userId, 3);   // 3 = User
            else return;                         // Отмена — выходим без изменений
            _adminService.LogAction(_adminUser.UserId, "Смена роли", username); // Запись в лог
            LoadUsers();                         // Обновляем таблицу
        }

        private void ToggleUserActive()          // Блокировка/разблокировка пользователя
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            { MessageBox.Show("Выберите пользователя."); return; }
            var row = dataGridViewUsers.SelectedRows[0];
            int userId = Convert.ToInt32(row.Cells[0].Value);     // [0] ID
            bool isActive = row.Cells[5].Value?.ToString() == "Да"; // [5] Активен: "Да" → true
            string username = row.Cells[1].Value?.ToString() ?? ""; // [1] Логин
            if (userId == _adminUser.UserId)     // Нельзя заблокировать себя
            { MessageBox.Show("Нельзя заблокировать себя."); return; }
            _adminService.ToggleUserActive(userId, !isActive); // Инвертируем: активен → заблокировать
            _adminService.LogAction(_adminUser.UserId, isActive ? "Блокировка" : "Разблокировка", username);
            LoadUsers();
        }

        private void DeleteUser()                // Полное удаление пользователя из системы
        {
            if (dataGridViewUsers.SelectedRows.Count == 0)
            { MessageBox.Show("Выберите пользователя."); return; }
            var row = dataGridViewUsers.SelectedRows[0];
            int userId = Convert.ToInt32(row.Cells[0].Value);     // [0] ID
            string username = row.Cells[1].Value?.ToString() ?? ""; // [1] Логин
            if (userId == _adminUser.UserId)     // Нельзя удалить себя
            { MessageBox.Show("Нельзя удалить себя."); return; }
            if (MessageBox.Show($"Удалить «{username}»?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            _adminService.DeleteUser(userId);    // Удаляет пользователя и все его данные (отзывы, займы, историю)
            _adminService.LogAction(_adminUser.UserId, "Удаление", username);
            LoadUsers();
        }

        private void LoadBooks()                 // Загрузка списка книг в таблицу
        {
            var books = _adminService.GetAllBooksForManagement(); // List<BookManageModel> — книги с доп. информацией
            dataGridViewBooks.Rows.Clear();

            foreach (var b in books)
            {
                dataGridViewBooks.Rows.Add(
                    b.BookId,                    // [0] colBookId — ID (скрытая)
                    b.Title,                     // [1] colTitle — Название
                    b.AuthorName,                // [2] colAuthor — Автор
                    b.GenreName,                 // [3] colGenre — Жанр
                    b.PublicationYear,           // [4] colYear — Год
                    b.BookType,                  // [5] colType — Тип (Печатная/Онлайн)
                    $"{b.Rating:F1}",            // [6] colRating — Рейтинг (одна цифра после запятой)
                    b.IsAvailable ? "Доступна" : "На руках", // [7] colStatus
                    $"{b.AvailableCopies}/{b.TotalCopies}",  // [8] colCopies — «3/5»
                    b.IsNew ? "Да" : "Нет",      // [9] colIsNew — Новинка
                    b.IsHit ? "Да" : "Нет",      // [10] colIsHit — Хит
                    b.LoansCount,                // [11] colBookLoans — Выдач
                    b.ReviewsCount               // [12] colBookReviews — Отзывов
                );
            }
        }

        private void AddBook() { using var f = new AddEditBookForm(null, _adminUser, _adminService); if (f.ShowDialog() == DialogResult.OK) LoadBooks(); } // null → новая книга
        private void EditBook() { if (dataGridViewBooks.SelectedRows.Count == 0) { MessageBox.Show("Выберите книгу."); return; } int id = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells[0].Value); using var f = new AddEditBookForm(id, _adminUser, _adminService); if (f.ShowDialog() == DialogResult.OK) LoadBooks(); } // id → редактирование
        private void DeleteBook() { if (dataGridViewBooks.SelectedRows.Count == 0) { MessageBox.Show("Выберите книгу."); return; } var r = dataGridViewBooks.SelectedRows[0]; int id = Convert.ToInt32(r.Cells[0].Value); string t = r.Cells[1].Value?.ToString() ?? ""; if (MessageBox.Show($"Удалить «{t}»?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return; _adminService.DeleteBook(id); _adminService.LogAction(_adminUser.UserId, "Удаление книги", t); LoadBooks(); }

        private void LoadAuthors()               // Загрузка списка авторов в таблицу
        {
            DataTable authors = _adminService.GetAuthorsWithBookCount(); // DataTable: AuthorId, AuthorName, BookCount
            dataGridViewAuthors.Rows.Clear();

            foreach (DataRow row in authors.Rows) // Перебираем строки DataTable
            {
                dataGridViewAuthors.Rows.Add(
                    Convert.ToInt32(row["AuthorId"]),    // [0] colAuthorId — ID (скрытая)
                    row["AuthorName"]?.ToString() ?? "", // [1] colAuthorName — Автор
                    Convert.ToInt32(row["BookCount"])    // [2] colAuthorBookCount — Книг
                );
            }
        }

        private void AddAuthor() { string n = InputBox("Имя автора:", "Добавить"); if (!string.IsNullOrWhiteSpace(n)) { _adminService.AddAuthor(n); _adminService.LogAction(_adminUser.UserId, "Добавление автора", n); LoadAuthors(); } } // n — имя из диалога
        private void EditAuthor() { if (dataGridViewAuthors.SelectedRows.Count == 0) { MessageBox.Show("Выберите автора."); return; } var r = dataGridViewAuthors.SelectedRows[0]; int id = Convert.ToInt32(r.Cells[0].Value); string c = r.Cells[1].Value?.ToString() ?? ""; string n = InputBox("Новое имя:", "Редактировать", c); if (!string.IsNullOrWhiteSpace(n) && n != c) { _adminService.UpdateAuthor(id, n); _adminService.LogAction(_adminUser.UserId, "Редактирование автора", $"{c} -> {n}"); LoadAuthors(); } } // c=текущее, n=новое
        private void DeleteAuthor() { if (dataGridViewAuthors.SelectedRows.Count == 0) { MessageBox.Show("Выберите автора."); return; } var r = dataGridViewAuthors.SelectedRows[0]; int id = Convert.ToInt32(r.Cells[0].Value); string n = r.Cells[1].Value?.ToString() ?? ""; if (!_adminService.DeleteAuthor(id)) { MessageBox.Show($"У автора «{n}» есть книги."); return; } _adminService.LogAction(_adminUser.UserId, "Удаление автора", n); LoadAuthors(); } // DeleteAuthor возвращает false если есть книги

        private void LoadGenres()                // Загрузка списка жанров в таблицу
        {
            DataTable genres = _adminService.GetGenresWithBookCount(); // DataTable: GenreId, GenreName, BookCount
            dataGridViewGenres.Rows.Clear();

            foreach (DataRow row in genres.Rows)
            {
                dataGridViewGenres.Rows.Add(
                    Convert.ToInt32(row["GenreId"]),     // [0] colGenreId — ID (скрытая)
                    row["GenreName"]?.ToString() ?? "",  // [1] colGenreName — Жанр
                    Convert.ToInt32(row["BookCount"])    // [2] colGenreBookCount — Книг
                );
            }
        }

        private void AddGenre() { string n = InputBox("Название жанра:", "Добавить"); if (!string.IsNullOrWhiteSpace(n)) { _adminService.AddGenre(n); _adminService.LogAction(_adminUser.UserId, "Добавление жанра", n); LoadGenres(); } }
        private void EditGenre() { if (dataGridViewGenres.SelectedRows.Count == 0) { MessageBox.Show("Выберите жанр."); return; } var r = dataGridViewGenres.SelectedRows[0]; int id = Convert.ToInt32(r.Cells[0].Value); string c = r.Cells[1].Value?.ToString() ?? ""; string n = InputBox("Новое название:", "Редактировать", c); if (!string.IsNullOrWhiteSpace(n) && n != c) { _adminService.UpdateGenre(id, n); _adminService.LogAction(_adminUser.UserId, "Редактирование жанра", $"{c} -> {n}"); LoadGenres(); } }
        private void DeleteGenre() { if (dataGridViewGenres.SelectedRows.Count == 0) { MessageBox.Show("Выберите жанр."); return; } var r = dataGridViewGenres.SelectedRows[0]; int id = Convert.ToInt32(r.Cells[0].Value); string n = r.Cells[1].Value?.ToString() ?? ""; if (!_adminService.DeleteGenre(id)) { MessageBox.Show($"К жанру «{n}» относятся книги."); return; } _adminService.LogAction(_adminUser.UserId, "Удаление жанра", n); LoadGenres(); }

        private void LoadPickups()               // Загрузка списка выдач/бронирований в таблицу
        {
            var pickups = _adminService.GetPendingPickups(); // List<BookPickup> — все бронирования
            dataGridViewPickups.Rows.Clear();

            foreach (var p in pickups)
            {
                dataGridViewPickups.Rows.Add(
                    p.PickupId,                  // [0] colPickupId — ID (скрытая)
                    p.ReservationCode,           // [1] colReservationCode — Код (8 символов)
                    p.BookTitle,                 // [2] colPickupBook — Книга
                    p.UserName,                  // [3] colPickupUser — Пользователь
                    p.LoanDate.ToString("dd.MM.yyyy HH:mm"), // [4] colPickupDate — Дата бронирования
                    p.Status,                    // [5] colPickupStatus — Статус (Ожидает/Выдана/Возвращена)
                    p.PickupDate?.ToString("dd.MM.yyyy HH:mm") ?? "-", // [6] colPickupActual — Дата выдачи (или прочерк)
                    string.IsNullOrEmpty(p.LibrarianName) ? "-" : p.LibrarianName // [7] colLibrarian — Библиотекарь
                );
            }
        }

        private void VerifyCode()                // Проверка кода бронирования из поля ввода
        {
            string code = textBoxReservationCode.Text.Trim().ToUpper(); // Убираем пробелы, в верхний регистр
            if (string.IsNullOrWhiteSpace(code)) { MessageBox.Show("Введите код."); return; }
            var pickup = _adminService.GetPickupByCode(code); // Ищем бронирование по коду
            if (pickup == null) { MessageBox.Show("Код не найден."); return; }
            if (pickup.Status == "Ожидает" && MessageBox.Show( // Если статус «Ожидает» — предлагаем выдать
                $"Код: {pickup.ReservationCode}\nКнига: {pickup.BookTitle}\nПользователь: {pickup.UserName}\n\nВыдать?",
                "Проверка", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { if (_adminService.ConfirmPickup(pickup.PickupId, _adminUser.UserId)) { MessageBox.Show("Выдана!"); _adminService.LogAction(_adminUser.UserId, "Выдача", $"{pickup.BookTitle}"); textBoxReservationCode.Clear(); LoadPickups(); } }
            else MessageBox.Show($"Статус: {pickup.Status}"); // Если не «Ожидает» — просто показываем статус
        }

        private void ConfirmPickup() { if (dataGridViewPickups.SelectedRows.Count == 0) { MessageBox.Show("Выберите."); return; } var r = dataGridViewPickups.SelectedRows[0]; int id = Convert.ToInt32(r.Cells[0].Value); if (r.Cells[5].Value?.ToString() != "Ожидает") { MessageBox.Show("Только ожидающие."); return; } if (_adminService.ConfirmPickup(id, _adminUser.UserId)) { MessageBox.Show("Выдана!"); _adminService.LogAction(_adminUser.UserId, "Выдача", id.ToString()); LoadPickups(); } }
        private void ReturnBookByLibrarian() { if (dataGridViewPickups.SelectedRows.Count == 0) { MessageBox.Show("Выберите."); return; } var r = dataGridViewPickups.SelectedRows[0]; int id = Convert.ToInt32(r.Cells[0].Value); string s = r.Cells[5].Value?.ToString() ?? ""; string b = r.Cells[2].Value?.ToString() ?? ""; if (s != "Выдана") { MessageBox.Show($"Статус: {s}"); return; } if (MessageBox.Show($"Возврат «{b}»?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return; if (_adminService.ReturnBookByLibrarian(id, _adminUser.UserId)) { MessageBox.Show("Возвращена!"); _adminService.LogAction(_adminUser.UserId, "Возврат", b); LoadPickups(); } }

        private void CancelReservationByLibrarian() // Отмена бронирования библиотекарем/админом
        {
            if (dataGridViewPickups.SelectedRows.Count == 0) { MessageBox.Show("Выберите запись."); return; }
            var r = dataGridViewPickups.SelectedRows[0];
            int id = Convert.ToInt32(r.Cells[0].Value);  // [0] PickupId
            string s = r.Cells[5].Value?.ToString() ?? ""; // [5] Статус
            string b = r.Cells[2].Value?.ToString() ?? ""; // [2] Книга
            string u = r.Cells[3].Value?.ToString() ?? ""; // [3] Пользователь
            string c = r.Cells[1].Value?.ToString() ?? ""; // [1] Код
            if (s != "Ожидает") { MessageBox.Show($"Только ожидающие. Статус: {s}"); return; } // Отменить можно только ожидающие
            if (MessageBox.Show($"Отменить бронь?\n\nКнига: {b}\nПользователь: {u}\nКод: {c}", "Отмена",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            if (_adminService.CancelReservation(id, _adminUser.UserId)) // Отмена: меняет статус, возвращает копию
            { MessageBox.Show("Бронь отменена!"); _adminService.LogAction(_adminUser.UserId, "Отмена брони", $"{b} -> {u}"); LoadPickups(); }
        }

        private string InputBox(string prompt, string title, string defaultValue = "") // Короткое имя для стандартного диалога ввода
            => Microsoft.VisualBasic.Interaction.InputBox(prompt, title, defaultValue); // prompt=подсказка, title=заголовок, defaultValue=текст по умолчанию

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Пустой обработчик, созданный дизайнером (не используется)
        }
    }
}