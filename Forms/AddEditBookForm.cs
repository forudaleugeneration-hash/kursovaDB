using System.Data;                             // DataTable, DataRow для работы с табличными данными из БД
using LibraryApp.Database;                     // DatabaseHelper — выполнение SQL-запросов к базе данных
using LibraryApp.Models;                       // Book, User — модели данных, описывающие таблицы БД
using LibraryApp.Services;                     // AdminService, BookService — сервисы бизнес-логики приложения

namespace LibraryApp.Forms                    // Все формы (окна) приложения живут в этом пространстве имён
{
    public partial class AddEditBookForm : Form // partial — класс разделён на логику (.cs) и дизайн (.Designer.cs); Form — стандартное окно Windows
    {
        private readonly int? _bookId;           // int? (nullable) — null = режим «добавление», число = режим «редактирование»; readonly — задаётся только в конструкторе
        private readonly User _adminUser;        // Текущий админ/библиотекарь, выполняющий операцию (нужен для логирования действий)
        private readonly AdminService _adminService; // Сервис для CRUD-операций с книгами, авторами, жанрами, обложками, PDF
        private readonly BookService _bookService;   // Сервис для получения книги по ID, обновления рейтинга
        private byte[]? _coverImageData;         // Массив байтов загруженной обложки; null — обложка не выбрана
        private byte[]? _pdfData;                // Массив байтов загруженного PDF; null — PDF не выбран
        public AddEditBookForm(int? bookId, User adminUser, AdminService adminService) // bookId=null → новая книга; bookId=число → редактирование
        {
            InitializeComponent();               // Создаёт все кнопки, поля, списки (метод из Designer.cs)
            _bookId = bookId;                    // Сохраняем ID книги: null для добавления, число для редактирования
            _adminUser = adminUser;              // Сохраняем пользователя для записи в лог (кто сделал действие)
            _adminService = adminService;        // Сохраняем сервис администрирования (передан извне из AdminForm)
            _bookService = new BookService();    // Создаём новый экземпляр сервиса книг (нужен только этой форме)

            SetupEvents();                       // Подписываемся на клики кнопок: Загрузить, Удалить, Сохранить, Отмена
            LoadAuthors();                       // Загружаем список авторов из БД в выпадающий список comboBoxAuthor
            LoadGenres();                        // Загружаем список жанров из БД в выпадающий список comboBoxGenre

            if (_bookId.HasValue)                // .HasValue — true если _bookId содержит число (не null) → режим редактирования
            {
                Text = "Редактирование книги";   // Меняем заголовок окна
                LoadBookData();                  // Заполняем поля формы данными существующей книги из БД
            }
            else                                 // _bookId == null → режим добавления новой книги
            {
                Text = "Добавление новой книги"; // Меняем заголовок окна
                comboBoxLanguage.SelectedIndex = 0; // Выбираем первый язык ("Русский") по умолчанию
            }
        }
        private void SetupEvents()
        {
            btnLoadCover.Click += (s, e) => LoadCover();     // Клик по «Загрузить обложку» → открыть диалог выбора файла
            btnDeleteCover.Click += (s, e) => DeleteCover(); // Клик по «Удалить обложку» → стереть обложку и скрыть кнопку
            btnLoadPdf.Click += (s, e) => LoadPdf();         // Клик по «Загрузить PDF» → открыть диалог выбора PDF
            btnDeletePdf.Click += (s, e) => DeletePdf();     // Клик по «Удалить PDF» → стереть PDF и скрыть кнопку
            btnSave.Click += (s, e) => SaveBook();           // Клик по «Сохранить» → проверить поля и сохранить книгу в БД
            btnCancel.Click += (s, e) => Close();            // Клик по «Отмена» → закрыть форму без сохранения
        }
        private void LoadAuthors()
        {
            var authors = _adminService.GetAuthors();        // DataTable со списком авторов (SQL: SELECT * FROM Authors ORDER BY AuthorName)
            comboBoxAuthor.DataSource = authors;             // Привязываем таблицу к выпадающему списку
            comboBoxAuthor.DisplayMember = "AuthorName";     // Показываем пользователю имя автора (столбец AuthorName)
            comboBoxAuthor.ValueMember = "AuthorId";         // При выборе возвращаем ID автора (столбец AuthorId)
        }
        private void LoadGenres()
        {
            var genres = _adminService.GetGenres();          // DataTable со списком жанров (SQL: SELECT * FROM Genres ORDER BY GenreName)
            comboBoxGenre.DataSource = genres;               // Привязываем таблицу к выпадающему списку
            comboBoxGenre.DisplayMember = "GenreName";       // Показываем пользователю название жанра
            comboBoxGenre.ValueMember = "GenreId";           // При выборе возвращаем ID жанра
        }
        private void LoadBookData()
        {
            var book = _bookService.GetBookById(_bookId!.Value); // ! — уверены что _bookId не null; получаем объект Book из БД по ID
            if (book == null) return;                         // Если книга не найдена — выходим (защита от удалённой книги)

            textBoxTitle.Text = book.Title;                   // Название книги в поле ввода
            comboBoxAuthor.SelectedValue = book.AuthorId;     // Выбираем автора по его ID в выпадающем списке
            comboBoxGenre.SelectedValue = book.GenreId;       // Выбираем жанр по его ID
            textBoxYear.Text = book.PublicationYear.ToString(); // Год издания (число → строка для отображения)
            comboBoxLanguage.SelectedItem = book.Language;    // Выбираем язык книги ("Русский", "Английский"...)
            richTextBoxAnnotation.Text = book.Annotation;     // Текст аннотации в многострочное поле
            checkBoxIsNew.Checked = book.IsNew;               // Галочка «Новинка»: true = отмечена
            checkBoxIsHit.Checked = book.IsHit;               // Галочка «Хит чтения»: true = отмечена
            checkBoxIsOnline.Checked = book.BookType == "Онлайн"; // Галочка «Онлайн»: сравнение типа книги со строкой "Онлайн"
            numericTotalCopies.Value = book.TotalCopies;      // Количество копий в числовое поле

            // --- Загрузка обложки ---
            var coverData = _adminService.GetBookCover(_bookId.Value); // Массив байтов обложки из БД (или null)
            if (coverData != null && coverData.Length > 0)     // Обложка существует и не пустая
            {
                _coverImageData = coverData;                   // Сохраняем в поле класса для возможной замены/удаления
                using var ms = new MemoryStream(coverData);    // MemoryStream — «файл в памяти» для работы с массивом байтов
                pictureBoxCover.Image = Image.FromStream(ms);  // Создаём картинку из потока байтов и показываем
                pictureBoxCover.SizeMode = PictureBoxSizeMode.Zoom; // Масштабируем с сохранением пропорций
                lblCoverStatus.Text = "Обложка загружена";     // Статус: обложка есть
                lblCoverStatus.ForeColor = Color.Green;        // Зелёный цвет — всё хорошо
                btnDeleteCover.Visible = true;                 // Показываем кнопку «Удалить обложку»
            }

            // --- Загрузка PDF ---
            var pdfData = _adminService.GetBookPdf(_bookId.Value); // Массив байтов PDF из БД (или null)
            if (pdfData != null && pdfData.Length > 0)         // PDF существует и не пустой
            {
                _pdfData = pdfData;                            // Сохраняем в поле класса
                lblPdfStatus.Text = "PDF загружен";            // Статус: PDF есть
                lblPdfStatus.ForeColor = Color.Green;          // Зелёный цвет
                btnDeletePdf.Visible = true;                   // Показываем кнопку «Удалить PDF»
            }
        }
        private void LoadCover()
        {
            using var openFileDialog = new OpenFileDialog      // Стандартное окно Windows «Выберите файл»; using — освободит ресурсы после
            {
                Title = "Выберите обложку книги",              // Заголовок диалогового окна
                Filter = "Изображения (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif" // Только картинки
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK) // Пользователь выбрал файл и нажал «Открыть»
            {
                try                                          // Блок для перехвата ошибок (битый файл, нет прав...)
                {
                    _coverImageData = File.ReadAllBytes(openFileDialog.FileName); // Читаем ВСЁ содержимое файла в массив байтов
                    using var ms = new MemoryStream(_coverImageData); // Создаём поток в памяти из массива байтов
                    pictureBoxCover.Image = Image.FromStream(ms); // Создаём картинку из потока и показываем
                    pictureBoxCover.SizeMode = PictureBoxSizeMode.Zoom; // Масштабируем с сохранением пропорций
                    lblCoverStatus.Text = Path.GetFileName(openFileDialog.FileName); // Только имя файла (не весь путь)
                    lblCoverStatus.ForeColor = Color.Green;    // Зелёный — успешно загружено
                    btnDeleteCover.Visible = true;             // Показываем кнопку удаления обложки
                }
                catch (Exception ex)                           // Если что-то пошло не так
                { MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void DeleteCover()
        {
            if (MessageBox.Show("Удалить обложку?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _coverImageData = null;                        // Обнуляем данные в памяти
                pictureBoxCover.Image = null;                  // Убираем картинку из PictureBox
                lblCoverStatus.Text = "Обложка не загружена";   // Меняем статус
                lblCoverStatus.ForeColor = Color.Gray;         // Серый — нейтрально
                btnDeleteCover.Visible = false;                // Скрываем кнопку удаления (нечего удалять)
                if (_bookId.HasValue)                          // Если редактируем существующую книгу
                    _adminService.DeleteBookCover(_bookId.Value); // Удаляем обложку из БД (SQL: UPDATE Books SET CoverImage = NULL)
            }
        }
        private void LoadPdf()
        {
            using var openFileDialog = new OpenFileDialog      // Стандартное окно выбора файла
            {
                Title = "Выберите PDF файл книги",             // Заголовок окна
                Filter = "PDF файлы (*.pdf)|*.pdf"             // Фильтр: только PDF
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK) // Пользователь выбрал PDF
            {
                try
                {
                    _pdfData = File.ReadAllBytes(openFileDialog.FileName); // Читаем весь PDF в массив байтов
                    lblPdfStatus.Text = Path.GetFileName(openFileDialog.FileName); // Показываем имя файла
                    lblPdfStatus.ForeColor = Color.Green;      // Зелёный — успешно
                    btnDeletePdf.Visible = true;               // Показываем кнопку удаления PDF
                    checkBoxIsOnline.Checked = true;           // Автоматически отмечаем как онлайн-книгу
                }
                catch (Exception ex)
                { MessageBox.Show($"Ошибка загрузки PDF: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void DeletePdf()
        {
            if (MessageBox.Show("Удалить PDF файл?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _pdfData = null;                               // Обнуляем данные в памяти
                lblPdfStatus.Text = "PDF не загружен";         // Меняем статус
                lblPdfStatus.ForeColor = Color.Gray;           // Серый — нейтрально
                btnDeletePdf.Visible = false;                  // Скрываем кнопку удаления
                checkBoxIsOnline.Checked = false;              // Снимаем галочку «Онлайн»
                if (_bookId.HasValue)                          // Если редактируем существующую книгу
                    _adminService.DeleteBookPdf(_bookId.Value); // Удаляем PDF из БД (SQL: UPDATE Books SET PdfContent = NULL, BookType = 'Печатная')
            }
        }
        private void SaveBook()
        {
            // --- Проверки обязательных полей ---
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))   // Пустое название? (null, "" или пробелы)
            { MessageBox.Show("Введите название книги.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (comboBoxAuthor.SelectedValue == null)           // Автор не выбран?
            { MessageBox.Show("Выберите автора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (comboBoxGenre.SelectedValue == null)            // Жанр не выбран?
            { MessageBox.Show("Выберите жанр.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (!int.TryParse(textBoxYear.Text, out int year))  // Год не число? TryParse — пытается преобразовать строку в int
            { MessageBox.Show("Введите корректный год.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            // --- Сбор данных из полей формы ---
            string title = textBoxTitle.Text;                    // Название книги
            int authorId = (int)comboBoxAuthor.SelectedValue;    // ID автора (явное приведение object → int)
            int genreId = (int)comboBoxGenre.SelectedValue;      // ID жанра
            string language = comboBoxLanguage.SelectedItem?.ToString() ?? "Русский"; // ?. — если не null, ToString(); ?? — если null, "Русский"
            string annotation = richTextBoxAnnotation.Text;      // Текст аннотации
            bool isNew = checkBoxIsNew.Checked;                  // Галочка «Новинка»
            bool isHit = checkBoxIsHit.Checked;                  // Галочка «Хит чтения»
            bool isOnline = checkBoxIsOnline.Checked || _pdfData != null; // Онлайн если отмечена галочка ИЛИ загружен PDF
            string bookType = isOnline ? "Онлайн" : "Печатная";   // Тернарный оператор: условие ? true : false
            int totalCopies = (int)numericTotalCopies.Value;      // Количество копий (decimal → int)

            // --- Сохранение в БД ---
            if (_bookId.HasValue)                                // РЕДАКТИРОВАНИЕ существующей книги
            {
                _adminService.UpdateBook(_bookId.Value, title, authorId, genreId, year, language, annotation, isNew, isHit, bookType, totalCopies); // SQL: UPDATE Books SET ... WHERE BookId = X
                if (_coverImageData != null)                     // Если загружена новая обложка
                    _adminService.UpdateBookCover(_bookId.Value, _coverImageData); // Сохраняем обложку в БД
                if (_pdfData != null)                            // Если загружен новый PDF
                    _adminService.UpdateBookPdf(_bookId.Value, _pdfData); // Сохраняем PDF в БД
                else if (!isOnline)                              // PDF не загружен И книга помечена как печатная
                    _adminService.DeleteBookPdf(_bookId.Value);  // Удаляем старый PDF из БД (если был)
                _adminService.LogAction(_adminUser.UserId, "Редактирование книги", title); // Запись в лог: кто, что, над чем
            }
            else                                                 // ДОБАВЛЕНИЕ новой книги
            {
                _adminService.AddBook(title, authorId, genreId, year, language, annotation, totalCopies); // SQL: INSERT INTO Books (...) VALUES (...)
                var result = DatabaseHelper.ExecuteScalar("SELECT MAX(BookId) FROM Books"); // Получаем ID только что созданной книги
                if (result != null && result != DBNull.Value)    // Если запрос вернул результат (не null и не DBNull)
                {
                    int newBookId = Convert.ToInt32(result);     // Преобразуем object в int — ID новой книги
                    if (_coverImageData != null)                 // Если загружена обложка
                        _adminService.UpdateBookCover(newBookId, _coverImageData); // Сохраняем обложку для новой книги
                    if (_pdfData != null)                        // Если загружен PDF
                        _adminService.UpdateBookPdf(newBookId, _pdfData); // Сохраняем PDF для новой книги
                }
                _adminService.LogAction(_adminUser.UserId, "Добавление книги", title); // Запись в лог
            }

            DialogResult = DialogResult.OK;                      // Сигнал родительской форме: «операция успешна»
            Close();                                             // Закрываем форму
        }
    }
}