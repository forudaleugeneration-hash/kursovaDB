namespace LibraryApp.Models                    // Пространство имён для всех моделей данных
{
    public class User                           // Модель пользователя — соответствует таблице Users в БД
    {
        public int UserId { get; set; }         // Уникальный ID пользователя (первичный ключ, автоинкремент)
        public string Username { get; set; } = string.Empty; // Логин для входа в систему (уникальный в БД)
        public string Password { get; set; } = string.Empty; // Пароль (в реальном проекте должен храниться в виде хеша, не открытым текстом)
        public string Email { get; set; } = string.Empty; // Электронная почта пользователя (необязательное поле)
        public string FullName { get; set; } = string.Empty; // Полное имя (отображается в приветствии и профиле)
        public DateTime RegistrationDate { get; set; } = DateTime.Now; // Дата регистрации; DateTime.Now — текущие дата и время по умолчанию
        public bool IsActive { get; set; } = true; // Активен ли пользователь; true = может входить, false = заблокирован
        public int RoleId { get; set; } = 3;   // ID роли: 1 = Admin, 2 = Librarian, 3 = User; 3 — значение по умолчанию для новых
        public bool NotifyNewBooks { get; set; } = true; // Уведомлять о новых поступлениях (настройка пока не используется в коде)
        public bool NotifyEvents { get; set; } = true;   // Уведомлять о событиях библиотеки (настройка пока не используется в коде)

        public string RoleName => RoleId switch  // Вычисляемое свойство (=> — лямбда): русское название роли по её ID
        {
            1 => "Администратор",               // RoleId = 1 → «Администратор»
            2 => "Библиотекарь",                // RoleId = 2 → «Библиотекарь»
            _ => "Пользователь"                 // _ — все остальные случаи (3 и любые другие) → «Пользователь»
        };

        public bool IsAdmin => RoleId == 1;     // Вычисляемое: true если пользователь — админ; == 1 — сравнение с ID роли админа
        public bool IsLibrarian => RoleId == 2; // Вычисляемое: true если пользователь — библиотекарь
        public bool CanManageLibrary => RoleId <= 2; // Вычисляемое: true если может управлять (админ ИЛИ библиотекарь); <= 2 — RoleId 1 или 2
    }
}