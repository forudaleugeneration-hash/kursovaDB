using LibraryApp.Services;                     // UserService — сервис для авторизации и регистрации пользователей

namespace LibraryApp.Forms
{
    public partial class LoginForm : Form       // partial — класс разделён на логику и дизайн; Form — окно Windows
    {
        private readonly UserService _userService; // Сервис для проверки логина/пароля и регистрации
        private static LoginForm? _instance;       // Статическая ссылка на единственный экземпляр формы (паттерн Singleton)
        private bool _isClosing = false;           // Флаг: true — форма закрывается корректно, false — выход из приложения

        private readonly Size _loginSize = new Size(400, 360);      // Размер окна в режиме входа (ширина 400, высота 360)
        private readonly Size _registerSize = new Size(400, 460);   // Размер окна в режиме регистрации (ширина 400, высота 460)

        public LoginForm()                       // Конструктор формы входа
        {
            InitializeComponent();               // Создаёт все элементы: поля, кнопки, галочку (метод из Designer.cs)
            _userService = new UserService();    // Создаём сервис пользователей
            SetupEvents();                       // Подписываемся на события кнопок и полей
            SetFormSize(false);                  // Устанавливаем размер и раскладку для режима входа
        }

        protected override void OnLoad(EventArgs e) // Вызывается при загрузке формы (перед показом)
        {
            base.OnLoad(e);                      // Вызываем метод родительского класса Form
            if (_instance != null && _instance != this) // Если уже есть другой экземпляр LoginForm
            {
                _instance.Close();               // Закрываем старый экземпляр (оставляем только один)
            }
            _instance = this;                    // Сохраняем ссылку на текущий экземпляр
        }

        private void SetupEvents()               // Подписка на все события формы
        {
            btnLogin.Click += BtnLogin_Click;    // Кнопка «Войти»
            btnRegister.Click += BtnRegister_Click; // Кнопка «Зарегистрироваться»
            chkShowRegister.CheckedChanged += ChkShowRegister_CheckedChanged; // Переключение галочки регистрации
            FormClosing += LoginForm_FormClosing; // Событие перед закрытием формы
            textBoxPassword.KeyPress += TextBoxPassword_KeyPress; // Нажатие клавиш в поле пароля (для Enter)
        }

        private void SetFormSize(bool isRegister) // Переключение между режимами входа и регистрации
        {
            if (isRegister)                      // Режим РЕГИСТРАЦИИ
            {
                this.ClientSize = _registerSize; // Увеличиваем размер окна (400x460)

                lblEmail.Visible = true;         // Показываем поле Email
                textBoxEmail.Visible = true;
                lblFullName.Visible = true;      // Показываем поле «Полное имя»
                textBoxFullName.Visible = true;

                lblTitle.Location = new Point(100, 15); // Заголовок «Библиотека» — выше
                lblTitle.Size = new Size(200, 30);

                lblUsername.Location = new Point(50, 60);  // «Логин:» — позиция по X и Y
                textBoxUsername.Location = new Point(50, 80); // Поле ввода логина

                lblPassword.Location = new Point(50, 115); // «Пароль:»
                textBoxPassword.Location = new Point(50, 135);

                lblEmail.Location = new Point(50, 170);    // «Email:»
                textBoxEmail.Location = new Point(50, 190);

                lblFullName.Location = new Point(50, 225); // «Полное имя:»
                textBoxFullName.Location = new Point(50, 245);

                chkShowRegister.Location = new Point(50, 285); // Галочка «Регистрация нового пользователя»

                btnLogin.Visible = false;        // Скрываем кнопку «Войти»
                btnRegister.Visible = true;      // Показываем кнопку «Зарегистрироваться»
                btnRegister.Location = new Point(130, 330);
                btnRegister.Size = new Size(140, 35);

                this.Text = "Регистрация";       // Меняем заголовок окна
            }
            else                                 // Режим ВХОДА
            {
                this.ClientSize = _loginSize;    // Уменьшаем размер окна (400x360)

                lblEmail.Visible = false;        // Скрываем поле Email
                textBoxEmail.Visible = false;
                lblFullName.Visible = false;     // Скрываем поле «Полное имя»
                textBoxFullName.Visible = false;

                lblTitle.Location = new Point(100, 20); // Заголовок — чуть ниже
                lblTitle.Size = new Size(200, 35);

                lblUsername.Location = new Point(50, 75);
                textBoxUsername.Location = new Point(50, 95);

                lblPassword.Location = new Point(50, 130);
                textBoxPassword.Location = new Point(50, 150);

                chkShowRegister.Location = new Point(50, 195);

                btnLogin.Visible = true;         // Показываем кнопку «Войти»
                btnLogin.Location = new Point(130, 245);
                btnLogin.Size = new Size(140, 40); // Кнопка чуть выше в режиме входа
                btnRegister.Visible = false;     // Скрываем кнопку регистрации

                this.Text = "Вход в систему";    // Меняем заголовок окна
            }

            this.CenterToScreen();               // Центрируем форму на экране после изменения размера
        }

        private void TextBoxPassword_KeyPress(object? sender, KeyPressEventArgs e) // Обработка нажатия Enter в поле пароля
        {
            if (e.KeyChar == (char)Keys.Enter)   // Нажат Enter (код клавиши 13)
            {
                if (chkShowRegister.Checked)     // Если в режиме регистрации
                {
                    BtnRegister_Click(sender, e); // Вызываем регистрацию
                }
                else
                {
                    BtnLogin_Click(sender, e);   // Вызываем вход
                }
                e.Handled = true;                // Говорим системе: «я обработал нажатие, не передавай дальше»
            }
        }

        private void ChkShowRegister_CheckedChanged(object? sender, EventArgs e) // Переключение галочки регистрации
        {
            SetFormSize(chkShowRegister.Checked); // Меняем размер и раскладку формы

            textBoxPassword.Clear();             // Очищаем пароль при переключении
            textBoxEmail.Clear();                // Очищаем Email
            textBoxFullName.Clear();             // Очищаем полное имя
            textBoxUsername.Focus();             // Переводим фокус на поле логина
        }

        private void BtnLogin_Click(object? sender, EventArgs e) // Обработка кнопки «Войти»
        {
            string username = textBoxUsername.Text.Trim(); // Логин, обрезаем пробелы по краям
            string password = textBoxPassword.Text;        // Пароль (пробелы важны, не обрезаем)

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) // Пустой логин или пароль
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var user = _userService.Login(username, password); // Проверяем логин/пароль в БД (SQL: SELECT ... WHERE Username=... AND Password=...)

            if (user != null)                    // Пользователь найден — вход успешен
            {
                this.Hide();                     // Скрываем форму входа (не закрываем!)
                textBoxPassword.Clear();         // Очищаем пароль для безопасности

                var mainForm = new MainForm(user); // Создаём главную форму, передаём пользователя
                mainForm.FormClosed += (s, args) => // Подписываемся на закрытие главной формы
                {
                    if (!_isClosing)             // Если это не выход из приложения
                    {
                        this.Show();             // Показываем форму входа снова
                        textBoxUsername.Focus(); // Фокус на поле логина
                    }
                };
                mainForm.Show();                 // Показываем главную форму
            }
            else                                 // Пользователь не найден
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Clear();         // Очищаем пароль
                textBoxPassword.Focus();         // Фокус на поле пароля для повторного ввода
            }
        }

        private void BtnRegister_Click(object? sender, EventArgs e) // Обработка кнопки «Зарегистрироваться»
        {
            string username = textBoxUsername.Text.Trim(); // Логин
            string password = textBoxPassword.Text;        // Пароль
            string email = textBoxEmail.Text.Trim();       // Email
            string fullName = textBoxFullName.Text.Trim(); // Полное имя

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) // Пустой логин или пароль
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password.Length < 3)             // Пароль слишком короткий
            {
                MessageBox.Show("Пароль должен быть не менее 3 символов.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool success = _userService.Register(username, password, email, fullName); // Регистрируем пользователя в БД

            if (success)                         // Регистрация успешна
            {
                MessageBox.Show("Регистрация успешна! Теперь вы можете войти.", "Успешно",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                chkShowRegister.Checked = false; // Переключаем обратно в режим входа
                textBoxPassword.Clear();         // Очищаем все поля
                textBoxEmail.Clear();
                textBoxFullName.Clear();
                textBoxUsername.Focus();         // Фокус на логин, после регистрации он остаёться прописанным
            }
            else                                 // Логин уже занят
            {
                MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosing(object? sender, FormClosingEventArgs e) // Перед закрытием формы
        {
            if (!_isClosing)                     // Если это не запланированный выход
            {
                _isClosing = true;               // Ставим флаг
                Application.Exit();              // Полностью выходим из приложения
            }
        }
    }
}