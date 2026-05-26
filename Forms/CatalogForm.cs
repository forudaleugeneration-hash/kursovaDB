using System.Data;                             // DataTable, DataRow для работы с результатами SQL-запросов
using LibraryApp.Database;                     // DatabaseHelper — выполнение запросов к базе данных

namespace LibraryApp.Forms
{
    public partial class CatalogForm : Form     // partial — класс разделён на логику и дизайн; Form — окно Windows
    {
        private readonly int _userId;            // ID текущего пользователя (для открытия карточки книги)

        public CatalogForm()                     // Конструктор без параметров (userId = 1 для совместимости)
        {
            InitializeComponent();               // Создаёт фильтры, таблицу, кнопки (метод из Designer.cs)
            _userId = 1;                         // Значение по умолчанию — первый пользователь
            SetupEvents();                       // Подписка на события формы и кнопок
            LoadGenres();                        // Загрузка списка жанров в фильтр
            LoadBooks();                         // Загрузка всех книг в таблицу
        }

        public CatalogForm(int userId)           // Конструктор с ID пользователя (из MainForm)
        {
            InitializeComponent();
            _userId = userId;                    // Сохраняем ID для открытия карточки книги
            SetupEvents();
            LoadGenres();
            LoadBooks();
        }

        private void SetupEvents()               // Подписка на все события формы
        {
            this.Load += CatalogForm_Load;       // Событие загрузки формы — установка значений по умолчанию
            this.btnApplyFilters.Click += BtnApplyFilters_Click; // Кнопка «Применить фильтры»
            this.btnResetFilters.Click += BtnResetFilters_Click; // Кнопка «Сбросить фильтры»
            this.comboBoxSortBy.SelectedIndexChanged += ComboBoxSortBy_SelectedIndexChanged; // Смена сортировки
            this.dataGridViewBooks.CellDoubleClick += DataGridViewBooks_CellDoubleClick; // Двойной клик по книге
        }

        private void CatalogForm_Load(object? sender, EventArgs e) // При загрузке формы
        {
            comboBoxSortBy.SelectedIndex = 0;    // Сортировка: «По популярности» (первый элемент)
            comboBoxLanguage.SelectedIndex = 0;  // Язык: «Все языки» (первый элемент)
        }

        private void LoadGenres()                // Загрузка списка жанров в выпадающий список фильтра
        {
            string query = "SELECT GenreId, GenreName FROM Genres ORDER BY GenreName"; // Все жанры по алфавиту
            DataTable genres = DatabaseHelper.ExecuteQuery(query); // Выполняем запрос

            DataRow emptyRow = genres.NewRow();  // Создаём новую пустую строку для пункта «Все жанры»
            emptyRow["GenreId"] = DBNull.Value;  // DBNull.Value — NULL в терминах базы данных (не число)
            emptyRow["GenreName"] = "Все жанры"; // Текст для отображения
            genres.Rows.InsertAt(emptyRow, 0);   // Вставляем пустую строку в начало таблицы (индекс 0)

            comboBoxGenre.DataSource = genres;   // Привязываем таблицу к выпадающему списку
            comboBoxGenre.DisplayMember = "GenreName"; // Показываем название жанра
            comboBoxGenre.ValueMember = "GenreId";     // При выборе возвращаем ID жанра
            comboBoxGenre.SelectedIndex = 0;     // Выбираем «Все жанры» по умолчанию
        }

        private void LoadBooks(string? filter = null) // Загрузка книг с учётом фильтров; filter — SQL-условие (или null)
        {
            try                                  // Блок для перехвата ошибок SQL
            {
                string query = @"SELECT b.BookId, b.Title, a.AuthorName, g.GenreName, 
                                b.PublicationYear, b.Language, 
                                CAST(b.Rating AS DECIMAL(3,1)) as Rating, 
                                b.Popularity, 
                                b.IsAvailable
                                FROM Books b 
                                INNER JOIN Authors a ON b.AuthorId = a.AuthorId 
                                INNER JOIN Genres g ON b.GenreId = g.GenreId ";
                // CAST(b.Rating AS DECIMAL(3,1)) — преобразует рейтинг в число с одним знаком после запятой
                // INNER JOIN Authors — подтягивает имя автора вместо AuthorId
                // INNER JOIN Genres — подтягивает название жанра вместо GenreId

                if (!string.IsNullOrEmpty(filter)) // Если есть условие фильтрации
                {
                    query += "WHERE " + filter + " "; // Добавляем WHERE с условием
                }

                string sortOrder = "ORDER BY b.Popularity DESC"; // Сортировка по умолчанию: популярные сверху
                if (comboBoxSortBy.SelectedItem != null) // Если выбран вариант сортировки
                {
                    sortOrder = comboBoxSortBy.SelectedItem.ToString() switch // switch — выбор по значению
                    {
                        "По дате поступления" => "ORDER BY b.DateAdded DESC", // Новые сверху
                        "По рейтингу" => "ORDER BY b.Rating DESC",             // Высокий рейтинг сверху
                        _ => "ORDER BY b.Popularity DESC"                      // _ — все остальные случаи
                    };
                }

                query += sortOrder;              // Добавляем сортировку к запросу

                DataTable books = DatabaseHelper.ExecuteQuery(query); // Выполняем итоговый SQL-запрос

                dataGridViewBooks.Rows.Clear();  // Очищаем старые строки перед загрузкой новых

                foreach (DataRow row in books.Rows) // Перебираем строки результата
                {
                    dataGridViewBooks.Rows.Add(  // Добавляем строку в таблицу (колонки из Designer.cs)
                        Convert.ToInt32(row["BookId"]),                  // [0] colBookId — ID (скрытая)
                        row["Title"]?.ToString() ?? "",                  // [1] colTitle — Название
                        row["AuthorName"]?.ToString() ?? "",             // [2] colAuthor — Автор
                        row["GenreName"]?.ToString() ?? "",              // [3] colGenre — Жанр
                        Convert.ToInt32(row["PublicationYear"]),         // [4] colYear — Год
                        row["Language"]?.ToString() ?? "",               // [5] colLanguage — Язык
                        $"{Convert.ToDecimal(row["Rating"]):F1} ⭐",     // [6] colRating — Рейтинг со звездой
                        Convert.ToInt32(row["Popularity"]),              // [7] colPopularity — Популярность
                        Convert.ToBoolean(row["IsAvailable"]) ? "✅ Да" : "❌ Нет" // [8] colAvailable — Доступна
                    );
                }

                lblResultCount.Text = $"Найдено книг: {books.Rows.Count}"; // Счётчик найденных книг
            }
            catch (Exception ex)                 // Если произошла ошибка SQL
            {
                MessageBox.Show($"Ошибка загрузки книг: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()              // Сбор всех фильтров и перезагрузка книг
        {
            var filterParts = new List<string>(); // Список частей SQL-условия (соединяются через AND)

            if (comboBoxGenre.SelectedValue != null && comboBoxGenre.SelectedValue != DBNull.Value) // Выбран конкретный жанр
                filterParts.Add($"b.GenreId = {comboBoxGenre.SelectedValue}"); // Добавляем условие по ID жанра

            if (!string.IsNullOrEmpty(textBoxYearFrom.Text) && int.TryParse(textBoxYearFrom.Text, out int yearFrom))
                filterParts.Add($"b.PublicationYear >= {yearFrom}"); // Год «от»: TryParse — проверяет что введено число

            if (!string.IsNullOrEmpty(textBoxYearTo.Text) && int.TryParse(textBoxYearTo.Text, out int yearTo))
                filterParts.Add($"b.PublicationYear <= {yearTo}");   // Год «до»

            if (!string.IsNullOrEmpty(textBoxAuthor.Text))           // Введён автор
                filterParts.Add($"a.AuthorName LIKE N'%{textBoxAuthor.Text.Replace("'", "''")}%'");
            // LIKE — поиск по подстроке; % — любые символы; Replace("'","''") — экранирование кавычек

            if (!string.IsNullOrEmpty(textBoxTitle.Text))            // Введено название
                filterParts.Add($"b.Title LIKE N'%{textBoxTitle.Text.Replace("'", "''")}%'");

            if (comboBoxLanguage.SelectedItem?.ToString() is string lang and not "Все языки") // Выбран конкретный язык
                filterParts.Add($"b.Language = N'{lang}'");
            // is string lang and not "Все языки" — проверка типа и значения в одном выражении (pattern matching)

            LoadBooks(string.Join(" AND ", filterParts)); // Соединяем все условия через AND и загружаем книги
        }

        private void BtnApplyFilters_Click(object? sender, EventArgs e) => ApplyFilters(); // Кнопка «Применить фильтры»

        private void BtnResetFilters_Click(object? sender, EventArgs e) // Кнопка «Сбросить фильтры»
        {
            comboBoxGenre.SelectedIndex = 0;     // Сбрасываем жанр на «Все жанры»
            textBoxYearFrom.Clear();             // Очищаем поле «Год от»
            textBoxYearTo.Clear();               // Очищаем поле «Год до»
            textBoxAuthor.Clear();               // Очищаем поле «Автор»
            textBoxTitle.Clear();                // Очищаем поле «Название»
            comboBoxLanguage.SelectedIndex = 0;  // Сбрасываем язык на «Все языки»
            comboBoxSortBy.SelectedIndex = 0;    // Сбрасываем сортировку на «По популярности»
            LoadBooks();                         // Загружаем все книги без фильтров
        }

        private void ComboBoxSortBy_SelectedIndexChanged(object? sender, EventArgs e) => ApplyFilters(); // Смена сортировки → перезагрузка

        private void DataGridViewBooks_CellDoubleClick(object? sender, DataGridViewCellEventArgs e) // Двойной клик по строке
        {
            if (e.RowIndex < 0) return;          // Клик по заголовку (RowIndex = -1) — игнорируем

            try
            {
                int bookId = Convert.ToInt32(dataGridViewBooks.Rows[e.RowIndex].Cells[0].Value); // ID из первой колонки [0]
                using var detailForm = new BookDetailForm(bookId, _userId); // Открываем карточку книги
                detailForm.ShowDialog();         // Ждём закрытия карточки
                ApplyFilters();                  // Обновляем список (мог измениться статус доступности)
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}