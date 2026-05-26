namespace LibraryApp.Models                    // Пространство имён для всех моделей данных
{
    public class Loan                          // Модель займа — соответствует таблице Loans в БД
    {
        public int LoanId { get; set; }        // Уникальный ID займа (первичный ключ, автоинкремент)
        public int UserId { get; set; }        // ID пользователя, взявшего книгу — ссылка на Users (внешний ключ)
        public int BookId { get; set; }        // ID книги — ссылка на Books (внешний ключ)
        public string BookTitle { get; set; } = string.Empty; // Название книги — НЕ хранится в Loans, заполняется через JOIN с Books
        public string AuthorName { get; set; } = string.Empty; // Имя автора — НЕ хранится в Loans, заполняется через JOIN с Authors
        public DateTime LoanDate { get; set; } = DateTime.Now; // Дата взятия книги; DateTime.Now — текущие дата и время
        public DateTime? ReturnDate { get; set; } // ? — может быть null; дата фактического возврата (null = ещё не вернули)
        public DateTime DueDate { get; set; }  // Дата, до которой нужно вернуть книгу (LoanDate + 14 или 30 дней)
        public string Status { get; set; } = "Выдана"; // Статус займа: «Выдана», «Забронирована», «Возвращена», «Отменена»
        public bool IsOnline { get; set; }     // true — онлайн-книга (читается через приложение), false — печатная
        public string BookType { get; set; } = "Печатная"; // Тип книги: «Печатная» или «Онлайн» (из Books.BookType)
        public bool HasPdf { get; set; }       // Есть ли у книги PDF-файл (заполняется через JOIN: CASE WHEN PdfContent IS NOT NULL)
        public string? ReservationCode { get; set; } // ? — может быть null; 8-значный код бронирования (только для печатных книг)

        public bool IsOverdue => Status == "Выдана" && DateTime.Now > DueDate; // Вычисляемое: просрочена ли книга; && — и статус «Выдана», и дата прошла
        public int DaysRemaining => Status != "Выдана" ? 0 : (DueDate - DateTime.Now).Days; // Сколько дней осталось до возврата; если не выдана — 0; .Days — разница в целых днях
    }
}