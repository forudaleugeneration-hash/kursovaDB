using System.Data;                             // DataTable, DataRow для результатов SQL-запросов
using LibraryApp.Database;                     // DatabaseHelper — выполнение SQL-запросов к БД

namespace LibraryApp.Forms
{
    public partial class SearchForm : Form      // partial — класс разделён на логику и дизайн; Form — окно Windows
    {
        private readonly string _searchType;     // Тип поиска: "author", "genre", "title" или "quick" (расширенный)
        private readonly int _userId;            // ID текущего пользователя (для открытия карточки книги)

        public SearchForm(string searchType)     // Конструктор без userId (для совместимости, userId = 1)
        {
            InitializeComponent();               // Создаёт все элементы формы (метод из Designer.cs)
            _searchType = searchType;            // Сохраняем тип поиска
            _userId = 1;                         // Значение по умолчанию
            SetupForm();                         // Настраиваем форму под тип поиска
            SetupEvents();                       // Подписываемся на события кнопок и полей
        }

        public SearchForm(string searchType, int userId) // Конструктор с userId (из MainForm)
        {
            InitializeComponent();
            _searchType = searchType;
            _userId = userId;                    // Сохраняем ID для открытия карточки
            SetupForm();
            SetupEvents();
        }

        private void SetupForm()                 // Настройка формы в зависимости от типа поиска
        {
            switch (_searchType)                 // switch — выбор по значению строки
            {
                case "author":                   // Поиск по автору
                    Text = "Поиск по автору";    // Заголовок окна
                    lblSearchBy.Text = "Введите имя автора:"; // Подсказка
                    textBoxSearch.Visible = true; // Показываем поле ввода текста
                    comboBoxSearch.Visible = false; // Скрываем выпадающий список
                    break;                       // Выход из switch
                case "genre":                    // Поиск по жанру
                    Text = "Поиск по жанру";
                    lblSearchBy.Text = "Выберите жанр:";
                    comboBoxSearch.Visible = true; // Показываем выпадающий список
                    textBoxSearch.Visible = false;  // Скрываем поле ввода
                    LoadGenres();                // Загружаем список жанров в comboBoxSearch
                    break;
                case "title":                    // Поиск по названию
                    Text = "Поиск по названию";
                    lblSearchBy.Text = "Введите название книги:";
                    textBoxSearch.Visible = true;
                    comboBoxSearch.Visible = false;
                    break;
                default:                         // Расширенный поиск (quick)
                    Text = "Расширенный поиск";
                    lblSearchBy.Text = "Введите ключевые слова:";
                    textBoxSearch.Visible = true;
                    comboBoxSearch.Visible = false;
                    break;
            }
        }

        private void SetupEvents()               // Подписка на события
        {
            btnSearch.Click += BtnSearch_Click;  // Кнопка «Поиск»
            btnClear.Click += BtnClear_Click;    // Кнопка «Очистить»
            dataGridViewResults.CellDoubleClick += DataGridViewResults_CellDoubleClick; // Двойной клик по строке
            textBoxSearch.KeyPress += TextBoxSearch_KeyPress; // Нажатие клавиш в поле поиска
        }

        private void TextBoxSearch_KeyPress(object? sender, KeyPressEventArgs e) // Обработка нажатия Enter
        {
            if (e.KeyChar == (char)Keys.Enter)   // Нажат Enter (код 13)
            {
                BtnSearch_Click(sender, e);      // Выполняем поиск
                e.Handled = true;                // Говорим системе что обработали
            }
        }

        private void LoadGenres()                // Загрузка списка жанров для выпадающего списка
        {
            string query = "SELECT GenreId, GenreName FROM Genres ORDER BY GenreName"; // Все жанры по алфавиту
            var genres = DatabaseHelper.ExecuteQuery(query); // DataTable с жанрами
            comboBoxSearch.DataSource = genres;  // Привязываем таблицу к списку
            comboBoxSearch.DisplayMember = "GenreName"; // Показываем название жанра
            comboBoxSearch.ValueMember = "GenreId";      // При выборе возвращаем ID
        }

        private void BtnSearch_Click(object? sender, EventArgs e) // Выполнение поиска
        {
            string searchValue = _searchType == "genre" // Если поиск по жанру
                ? comboBoxSearch.SelectedValue?.ToString() ?? "" // Берём значение из выпадающего списка
                : textBoxSearch.Text.Trim();           // Иначе берём текст из поля ввода

            if (string.IsNullOrWhiteSpace(searchValue)) // Пустой запрос
            {
                MessageBox.Show("Введите поисковый запрос.", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT b.BookId, b.Title, a.AuthorName, g.GenreName, 
                            b.PublicationYear, CAST(b.Rating AS DECIMAL(3,1)) as Rating, b.IsAvailable 
                            FROM Books b 
                            INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                            INNER JOIN Genres g ON b.GenreId = g.GenreId 
                            WHERE ";              // Базовая часть SQL-запроса

            query += _searchType switch           // Добавляем условие WHERE в зависимости от типа поиска
            {
                "author" => $"a.AuthorName LIKE N'%{searchValue.Replace("'", "''")}%'", // LIKE — поиск по подстроке
                "genre" => $"b.GenreId = {searchValue}",  // Точное совпадение по ID жанра
                "title" => $"b.Title LIKE N'%{searchValue.Replace("'", "''")}%'", // Поиск по названию
                _ => $@"(b.Title LIKE N'%{searchValue.Replace("'", "''")}%' 
                       OR a.AuthorName LIKE N'%{searchValue.Replace("'", "''")}%' 
                       OR b.Annotation LIKE N'%{searchValue.Replace("'", "''")}%')" // Расширенный: ищем везде
            };

            query += " ORDER BY b.Popularity DESC"; // Сортировка: популярные сверху

            try
            {
                DataTable searchResults = DatabaseHelper.ExecuteQuery(query); // Выполняем SQL

                dataGridViewResults.Rows.Clear();    // Очищаем старые результаты

                foreach (DataRow row in searchResults.Rows) // Перебираем найденные книги
                {
                    dataGridViewResults.Rows.Add(     // Добавляем строку в таблицу (колонки из Designer.cs)
                        Convert.ToInt32(row["BookId"]),                  // [0] colResultId — ID (скрытая)
                        row["Title"]?.ToString() ?? "",                  // [1] colResultTitle — Название
                        row["AuthorName"]?.ToString() ?? "",             // [2] colResultAuthor — Автор
                        row["GenreName"]?.ToString() ?? "",              // [3] colResultGenre — Жанр
                        Convert.ToInt32(row["PublicationYear"]),         // [4] colResultYear — Год
                        $"{Convert.ToDecimal(row["Rating"]):F1} ⭐",     // [5] colResultRating — Рейтинг со звездой
                        Convert.ToBoolean(row["IsAvailable"]) ? "✅ Да" : "❌ Нет" // [6] colResultAvailable — Доступна
                    );
                }

                lblResults.Text = $"Результаты поиска: {searchResults.Rows.Count}"; // Счётчик результатов

                if (searchResults.Rows.Count == 0)   // Ничего не найдено
                {
                    MessageBox.Show("По вашему запросу ничего не найдено.", "Результаты поиска",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)                     // Ошибка SQL
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewResults_CellDoubleClick(object? sender, DataGridViewCellEventArgs e) // Двойной клик по книге
        {
            if (e.RowIndex < 0) return;              // Клик по заголовку — игнорируем

            try
            {
                int bookId = Convert.ToInt32(dataGridViewResults.Rows[e.RowIndex].Cells[0].Value); // ID из колонки [0]
                using var detailForm = new BookDetailForm(bookId, _userId); // Открываем карточку книги
                detailForm.ShowDialog();             // Ждём закрытия
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void BtnClear_Click(object? sender, EventArgs e) // Кнопка «Очистить»
        {
            textBoxSearch.Clear();                   // Очищаем поле ввода
            dataGridViewResults.Rows.Clear();        // Очищаем таблицу результатов
            lblResults.Text = "Результаты поиска:";  // Сбрасываем счётчик
        }
    }
}