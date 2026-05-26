using LibraryApp.Database;                     // DatabaseHelper — выполнение SQL-запросов (для GetFavoriteGenreName)
using LibraryApp.Models;                       // Модели: Book, User — структуры данных
using LibraryApp.Services;                     // Сервисы: BookService, RecommendationService, AdminService

namespace LibraryApp.Forms
{
    public partial class MainForm : Form        // partial — класс разделён на логику и дизайн; Form — окно Windows
    {
        private readonly BookService _bookService;                // Сервис для получения популярных и новых книг
        private readonly RecommendationService _recommendationService; // Сервис для персональных рекомендаций
        private readonly AdminService _adminService;              // Сервис для загрузки обложек из БД
        private readonly User _currentUser;                       // Текущий вошедший пользователь
        private bool _isLoggingOut = false;                       // Флаг: true — выход в LoginForm, false — закрытие приложения

        public MainForm(User user)                               // Конструктор: user — пользователь после входа
        {
            InitializeComponent();                                // Создаёт все элементы формы (метод из Designer.cs)
            _currentUser = user;                                 // Сохраняем пользователя для персонализации
            _bookService = new BookService();                    // Сервис книг
            _recommendationService = new RecommendationService(); // Сервис рекомендаций
            _adminService = new AdminService();                  // Сервис для обложек

            LoadUserInfo();                                      // Показываем приветствие и роль пользователя
            CheckAdminAccess();                                  // Показываем кнопку «Админ» для админа/библиотекаря
            SetupEvents();                                       // Подписываемся на все клики и события формы
            LoadData();                                          // Загружаем книги, рекомендации, новости
        }

        private void LoadUserInfo()                              // Отображение приветствия и роли пользователя
        {
            lblWelcome.Text = $"Добро пожаловать, {_currentUser.FullName}"; // «Добро пожаловать, Иван Иванов»
            string roleEmoji = _currentUser.RoleId switch        // switch — выбор эмодзи по ID роли
            {
                1 => "👑",                                       // Admin — корона
                2 => "📋",                                       // Librarian — планшет
                _ => "👤"                                        // _ — все остальные (User) — силуэт
            };
            lblRole.Text = $"{roleEmoji} {_currentUser.RoleName}"; // «👑 Администратор»
        }

        private void CheckAdminAccess() => btnAdminPanel.Visible = _currentUser.CanManageLibrary; // CanManageLibrary — true для Admin и Librarian

        private void SetupEvents()                               // Подписка на все события формы
        {
            btnCatalog.Click += (s, e) => OpenCatalog();          // Кнопка «Каталог»
            btnProfile.Click += (s, e) => OpenProfile();          // Кнопка «Профиль»
            btnAdminPanel.Click += (s, e) => OpenAdmin();         // Кнопка «Админ» (только для сотрудников)
            btnLogout.Click += (s, e) => Logout();                // Кнопка «Выход»
            btnQuickSearch.Click += (s, e) => QuickSearch();      // Кнопка «Найти» (быстрый поиск)
            btnQuickSearchAuthor.Click += (s, e) => SearchBy("author"); // Поиск по автору
            btnQuickSearchGenre.Click += (s, e) => SearchBy("genre");   // Поиск по жанру
            btnQuickSearchTitle.Click += (s, e) => SearchBy("title");   // Поиск по названию
            textBoxQuickSearch.KeyPress += (s, e) =>              // Нажатие клавиши в поле быстрого поиска
            {
                if (e.KeyChar == (char)Keys.Enter)                // Нажат Enter
                { QuickSearch(); e.Handled = true; }              // Выполняем поиск, говорим что обработали
            };
            FormClosing += (s, e) =>                               // Событие перед закрытием формы
            {
                if (_isLoggingOut) return;                        // Если это выход в LoginForm — не спрашиваем
                if (e.CloseReason == CloseReason.UserClosing)      // Закрытие пользователем (крестик)
                {
                    if (MessageBox.Show("Выйти из программы?", "",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        e.Cancel = true;                          // Отмена — не закрываем
                    else Application.Exit();                      // Да — полный выход из приложения
                }
            };
            FormClosed += (s, e) =>                                // Событие после закрытия формы
            {
                if (_isLoggingOut)                                 // Выход в LoginForm
                {
                    var loginForm = Application.OpenForms.OfType<LoginForm>().FirstOrDefault(); // Ищем существующую форму входа
                    if (loginForm != null) { loginForm.Show(); loginForm.Focus(); } // Показываем найденную
                    else new LoginForm().Show();                   // Или создаём новую
                }
                else Application.Exit();                           // Полный выход
            };
        }

        private void LoadData()                                    // Загрузка всех данных на главную страницу
        {
            LoadPopularBooks();                                    // Хиты чтения (вкладка 1)
            LoadNewBooks();                                        // Новинки (вкладка 2)
            LoadRecommendations();                                 // Рекомендуемые (вкладка 3)
            LoadTrendingBooks();                                   // Тренды в списке рекомендаций
        }

        private void LoadPopularBooks()                            // Загрузка популярных книг (IsHit или Popularity > 50)
        {
            flowLayoutPopular.Controls.Clear();                    // Очищаем старые карточки
            foreach (var book in _bookService.GetPopularBooks(10)) // 10 самых популярных
                flowLayoutPopular.Controls.Add(CreateBookCardFromTemplate(book)); // Клонируем шаблон и заполняем данными
        }

        private void LoadNewBooks()                                // Загрузка новинок (IsNew = 1)
        {
            flowLayoutNew.Controls.Clear();
            foreach (var book in _bookService.GetNewBooks(10))
                flowLayoutNew.Controls.Add(CreateBookCardFromTemplate(book));
        }

        private void LoadRecommendations()                         // Загрузка персональных рекомендаций
        {
            flowLayoutRecommended.Controls.Clear();
            var recommendations = _recommendationService.GetPersonalRecommendations(_currentUser.UserId); // По любимому жанру
            string genreName = GetFavoriteGenreName(_currentUser.UserId); // Название любимого жанра
            lblRecommendationInfo.Text = !string.IsNullOrEmpty(genreName)
                ? $"📚 Рекомендации в жанре «{genreName}»"          // Показываем жанр
                : "📚 Рекомендуемые книги";                        // Или общий заголовок
            foreach (var book in recommendations)
                flowLayoutRecommended.Controls.Add(CreateBookCardFromTemplate(book));
        }

        private void LoadTrendingBooks()                           // Загрузка популярных книг в список (нижняя панель)
        {
            listBoxRecommendations.Items.Clear();
            foreach (var book in _recommendationService.GetTrendingBooks())
                listBoxRecommendations.Items.Add($"🔥 {book.Title} - {book.AuthorName} (Рейтинг: {book.Rating:F1})");
        }

        private string GetFavoriteGenreName(int userId)            // Определение любимого жанра пользователя
        {
            string query = $@"SELECT TOP 1 g.GenreName FROM ReadHistory rh 
                             INNER JOIN Books b ON rh.BookId = b.BookId 
                             INNER JOIN Genres g ON b.GenreId = g.GenreId 
                             WHERE rh.UserId = {userId} GROUP BY g.GenreName ORDER BY COUNT(*) DESC"; // Жанр с наибольшим числом прочтений
            return DatabaseHelper.ExecuteScalar(query)?.ToString() ?? ""; // Возвращает название жанра или пустую строку
        }

        private Panel CreateBookCardFromTemplate(Book book)        // Создание карточки книги из шаблона cardTemplate
        {
            Panel card = ClonePanel(cardTemplate);                 // Клонируем шаблон со всеми свойствами

            Panel cover = (Panel)card.Controls["coverTemplate"];   // Находим панель обложки по имени
            Label coverIcon = (Label)cover.Controls["coverIconTemplate"]; // Иконка-заглушка 📚
            Label title = (Label)card.Controls["titleTemplate"];   // Надпись названия
            Label author = (Label)card.Controls["authorTemplate"]; // Надпись автора
            Label rating = (Label)card.Controls["ratingTemplate"]; // Надпись рейтинга
            Label status = (Label)card.Controls["statusTemplate"]; // Надпись статуса
            Button detail = (Button)card.Controls["detailTemplate"]; // Кнопка «Подробнее»

            var coverData = _adminService.GetBookCover(book.BookId); // Загружаем обложку из БД
            if (coverData != null && coverData.Length > 0)         // Обложка существует
            {
                try
                {
                    using var ms = new MemoryStream(coverData);    // Поток в памяти из массива байтов
                    var pb = new PictureBox                        // Создаём PictureBox для картинки
                    {
                        Image = Image.FromStream(ms),              // Картинка из потока байтов
                        SizeMode = PictureBoxSizeMode.Zoom,        // Масштабирование с сохранением пропорций
                        Dock = DockStyle.Fill                      // Растянуть на весь coverTemplate
                    };
                    cover.Controls.Clear();                        // Удаляем иконку-заглушку
                    cover.BackColor = Color.Transparent;           // Убираем синий фон панели
                    cover.Controls.Add(pb);                        // Добавляем картинку
                }
                catch { coverIcon.Text = "📚"; }                   // Ошибка — оставляем заглушку
            }

            title.Text = book.Title.Length > 25 ? book.Title[..22] + "..." : book.Title; // Обрезаем длинные названия
            author.Text = book.AuthorName;                         // Имя автора
            rating.Text = $"⭐ {book.Rating:F1}";                  // Рейтинг: «⭐ 4.5»
            status.Text = book.IsAvailable || book.BookType == "Онлайн" ? "✅ Доступна" : "❌ На руках"; // Статус
            status.ForeColor = book.IsAvailable || book.BookType == "Онлайн" ? Color.Green : Color.Red; // Цвет статуса

            detail.Tag = book.BookId;                              // Сохраняем ID книги в кнопке для обработчика
            detail.Click += (s, e) =>                               // Клик по кнопке «Подробнее»
            {
                if (s is Button btn && btn.Tag is int bId)         // Извлекаем ID книги из Tag
                {
                    using var form = new BookDetailForm(bId, _currentUser.UserId); // Открываем карточку книги
                    form.ShowDialog();
                    LoadData();                                    // Обновляем данные после возврата
                }
            };

            return card;
        }

        private Panel ClonePanel(Panel source)                     // Клонирование Panel с сохранением свойств
        {
            Panel clone = new Panel
            {
                Width = source.Width,
                Height = source.Height,      // Размеры из шаблона
                BorderStyle = source.BorderStyle,                  // Стиль рамки
                BackColor = source.BackColor,                      // Цвет фона
                Margin = source.Margin,
                Padding = source.Padding   // Отступы
            };
            foreach (Control control in source.Controls)           // Копируем все дочерние элементы
                clone.Controls.Add(CloneControl(control));         // Рекурсивное клонирование каждого контрола
            return clone;
        }

        private Control CloneControl(Control source)               // Клонирование любого контрола по его типу
        {
            Control clone;                                         // Переменная для клона

            if (source is Panel srcPanel)                          // Если это Panel
            {
                clone = new Panel
                {
                    Width = srcPanel.Width,
                    Height = srcPanel.Height,
                    Location = srcPanel.Location,
                    BackColor = srcPanel.BackColor,
                    BorderStyle = srcPanel.BorderStyle,
                    Name = srcPanel.Name,
                    Dock = srcPanel.Dock
                };
                foreach (Control child in srcPanel.Controls)       // Копируем дочерние элементы Panel
                    clone.Controls.Add(CloneControl(child));
            }
            else if (source is Label srcLabel)                     // Если это Label (надпись)
            {
                clone = new Label
                {
                    Text = srcLabel.Text,
                    Location = srcLabel.Location,
                    AutoSize = srcLabel.AutoSize,
                    Font = srcLabel.Font,
                    ForeColor = srcLabel.ForeColor,
                    BackColor = srcLabel.BackColor,
                    TextAlign = srcLabel.TextAlign,
                    Dock = srcLabel.Dock,
                    Name = srcLabel.Name
                };
                if (!srcLabel.AutoSize) clone.Size = srcLabel.Size; // Если фиксированный размер — копируем
            }
            else if (source is Button srcButton)                   // Если это Button (кнопка)
            {
                clone = new Button
                {
                    Text = srcButton.Text,
                    Location = srcButton.Location,
                    Size = srcButton.Size,
                    Font = srcButton.Font,
                    BackColor = srcButton.BackColor,
                    ForeColor = srcButton.ForeColor,
                    FlatStyle = srcButton.FlatStyle,
                    Name = srcButton.Name
                };
            }
            else                                                   // Для всех остальных типов контролов
            {
                clone = new Control { Location = source.Location, Size = source.Size, Name = source.Name };
            }

            return clone;
        }

        private void OpenCatalog() { using var f = new CatalogForm(_currentUser.UserId); f.ShowDialog(); LoadData(); } // Открыть каталог
        private void OpenProfile() { using var f = new ProfileForm(_currentUser); f.ShowDialog(); LoadData(); }       // Открыть профиль
        private void OpenAdmin() { using var f = new AdminForm(_currentUser); f.ShowDialog(); LoadData(); }           // Открыть админ-панель

        private void Logout()                                     // Выход из системы (возврат к форме входа)
        {
            if (MessageBox.Show("Выйти из системы?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            _isLoggingOut = true;                                  // Ставим флаг «выход в LoginForm»
            Close();                                               // Закрываем главную форму
        }

        private void QuickSearch() { if (!string.IsNullOrWhiteSpace(textBoxQuickSearch.Text)) { using var f = new SearchForm("quick", _currentUser.UserId); f.ShowDialog(); } } // Быстрый поиск по тексту
        private void SearchBy(string type) { using var f = new SearchForm(type, _currentUser.UserId); f.ShowDialog(); } // Поиск по типу (author/genre/title)
    }
}