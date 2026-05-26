namespace LibraryApp.Models                    // Пространство имён для всех моделей данных
{
    public class Reservation                    // Модель бронирования — может использоваться для отчётов или расширения функционала
    {
        public int ReservationId { get; set; }  // Уникальный ID бронирования (первичный ключ, автоинкремент)
        public string ReservationCode { get; set; } = string.Empty; // 8-значный код бронирования (например, «ABC12345»)
        public int UserId { get; set; }         // ID пользователя, забронировавшего книгу — ссылка на Users (внешний ключ)
        public string Username { get; set; } = string.Empty; // Логин пользователя — НЕ хранится здесь, заполняется через JOIN с Users
        public int BookId { get; set; }         // ID забронированной книги — ссылка на Books (внешний ключ)
        public string BookTitle { get; set; } = string.Empty; // Название книги — НЕ хранится здесь, заполняется через JOIN с Books
        public string AuthorName { get; set; } = string.Empty; // Имя автора — НЕ хранится здесь, заполняется через JOIN с Authors
        public DateTime ReservationDate { get; set; } // Дата создания бронирования (когда пользователь нажал «Забронировать»)
        public DateTime ExpiryDate { get; set; } // Дата истечения брони (если не забрали вовремя — бронь сгорает)
        public string Status { get; set; } = "Активно"; // Статус брони: «Активно», «Выдана», «Отменена», «Истекла»
        public int? LibrarianId { get; set; }   // ? — может быть null; ID библиотекаря, выдавшего книгу (null = ещё не выдана)
        public string LibrarianName { get; set; } = string.Empty; // Имя библиотекаря — НЕ хранится здесь, заполняется через JOIN с Users
        public bool IsExpired => DateTime.Now > ExpiryDate; // Вычисляемое: истекла ли бронь; true если текущая дата позже даты истечения
        public int DaysRemaining => (ExpiryDate - DateTime.Now).Days; // Сколько дней осталось до истечения брони; .Days — целые дни
    }
}