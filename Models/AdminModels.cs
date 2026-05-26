namespace LibraryApp.Models                      // Пространство имён для всех моделей данных приложения
{

    // Модель записи лога действий администратора/библиотекаря

    public class AdminLog                        // Таблица AdminLogs — журнал действий сотрудников
    {
        public int LogId { get; set; }           // Первичный ключ, автоинкремент, грубо говоря, номер действия какого либо дйствия
        public int AdminId { get; set; }         // ID сотрудника, выполнившего действие (внешний ключ на Users)
        public string AdminName { get; set; } = string.Empty; // Имя сотрудника (заполняется через JOIN при чтении)
        public string Action { get; set; } = string.Empty;   // Тип действия: «Выдача», «Возврат», «Смена роли»...
        public string Details { get; set; } = string.Empty;  // Подробности: название книги, имя пользователя
        public DateTime ActionDate { get; set; } // Дата и время выполнения действия
    }


    // Модель пользователя с дополнительной информацией для админ-панели

    public class UserWithRole : User             // : User — наследует все свойства из класса User
    {
        public new string RoleName { get; set; } = string.Empty; // new — скрывает свойство RoleName из User (своя реализация)
        public int LoansCount { get; set; }      // Количество активных займов пользователя (из подзапроса SQL)
        public int ReviewsCount { get; set; }    // Количество оставленных отзывов (из подзапроса SQL)
    }


    // Модель книги с дополнительной информацией для админ-панели

    public class BookManageModel : Book          // : Book — наследует все свойства книги
    {
        public int LoansCount { get; set; }      // Сколько раз книгу брали (из подзапроса SQL)
        public int ReviewsCount { get; set; }    // Сколько отзывов оставлено (из подзапроса SQL)
    }


    // Модель бронирования/выдачи книги (таблица BookPickups)

    public class BookPickup                      // Таблица BookPickups — связка между бронью и выдачей
    {
        public int PickupId { get; set; }        // Первичный ключ, автоинкремент
        public int LoanId { get; set; }          // ID займа из таблицы Loans (внешний ключ)
        public int BookId { get; set; }          // ID книги (внешний ключ на Books)
        public int UserId { get; set; }          // ID пользователя, забронировавшего книгу (внешний ключ на Users)
        public string BookTitle { get; set; } = string.Empty;  // Название книги (заполняется через JOIN при чтении)
        public string UserName { get; set; } = string.Empty;   // Имя пользователя (заполняется через JOIN при чтении)
        public string ReservationCode { get; set; } = string.Empty; // 8-значный код бронирования (генерируется случайно)
        public DateTime? PickupDate { get; set; } // Дата фактической выдачи книги; ? — может быть null (ещё не выдана)
        public DateTime LoanDate { get; set; }   // Дата создания бронирования
        public string Status { get; set; } = "Ожидает"; // Статус: «Ожидает», «Выдана», «Возвращена», «Отменена»
        public string LibrarianName { get; set; } = string.Empty; // Имя библиотекаря, выдавшего книгу (из JOIN)
    }
}