namespace LibraryApp.Models                    // Пространство имён для всех моделей данных
{
    public class Review                         // Модель отзыва — соответствует таблице Reviews в БД
    {
        public int ReviewId { get; set; }       // Уникальный ID отзыва (первичный ключ, автоинкремент)
        public int UserId { get; set; }         // ID пользователя, оставившего отзыв — ссылка на Users (внешний ключ)
        public string Username { get; set; } = string.Empty; // Логин пользователя — НЕ хранится в Reviews, заполняется через JOIN с Users
        public int BookId { get; set; }         // ID книги, на которую оставлен отзыв — ссылка на Books (внешний ключ)
        public string BookTitle { get; set; } = string.Empty; // Название книги — НЕ хранится в Reviews, заполняется через JOIN с Books
        public int Rating { get; set; }         // Оценка от 1 до 5 (в БД: CHECK (Rating BETWEEN 1 AND 5))
        public string Comment { get; set; } = string.Empty; // Текст отзыва (может быть длинным — NVARCHAR(MAX) в БД)
        public DateTime ReviewDate { get; set; } = DateTime.Now; // Дата отзыва; DateTime.Now — текущие дата и время по умолчанию
    }
}