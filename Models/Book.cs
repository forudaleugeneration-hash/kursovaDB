namespace LibraryApp.Models                    // Пространство имён для всех моделей данных
{
    public class Book                          // Модель книги — соответствует таблице Books в БД
    {
        public int BookId { get; set; }        // Уникальный ID книги (первичный ключ, автоинкремент)
        public string Title { get; set; } = string.Empty; // Название книги; = string.Empty — значение по умолчанию (пустая строка, а не null)
        public int AuthorId { get; set; }      // ID автора — ссылка на таблицу Authors (внешний ключ)
        public string AuthorName { get; set; } = string.Empty; // Имя автора — НЕ хранится в Books, заполняется через JOIN с Authors при чтении
        public int GenreId { get; set; }       // ID жанра — ссылка на таблицу Genres (внешний ключ)
        public string GenreName { get; set; } = string.Empty; // Название жанра — НЕ хранится в Books, заполняется через JOIN с Genres при чтении
        public int PublicationYear { get; set; } // Год издания книги (например, 1951)
        public string Language { get; set; } = "Русский"; // Язык книги; "Русский" — значение по умолчанию для новых книг
        public string Annotation { get; set; } = string.Empty; // Аннотация (краткое описание книги)
        public byte[]? CoverImage { get; set; } // ? — может быть null; массив байтов обложки (хранится в БД как VARBINARY(MAX))
        public byte[]? PdfContent { get; set; } // ? — может быть null; массив байтов PDF-файла (только для онлайн-книг)
        public string BookType { get; set; } = "Печатная"; // Тип книги: «Печатная» (нужно забирать) или «Онлайн» (можно читать сразу)
        public int TotalCopies { get; set; } = 1; // Общее количество экземпляров книги в библиотеке
        public int AvailableCopies { get; set; } = 1; // Доступное количество экземпляров (уменьшается при бронировании)
        public decimal Rating { get; set; }    // Средний рейтинг книги (decimal — дробное число с точностью до копеек)
        public int Popularity { get; set; }    // Счётчик популярности (увеличивается при каждом взятии книги)
        public bool IsNew { get; set; }        // Признак «Новинка» (true — показывается во вкладке «Новинки»)
        public bool IsHit { get; set; }        // Признак «Хит чтения» (true — показывается во вкладке «Хиты»)
        public bool IsAvailable { get; set; } = true; // Доступна ли книга для бронирования; true = можно взять
        public DateTime DateAdded { get; set; } = DateTime.Now; // Дата добавления книги в базу; DateTime.Now — текущая дата и время
        public bool HasPdf => PdfContent != null && PdfContent.Length > 0; // Вычисляемое свойство (=> — лямбда): true если загружен PDF; && — логическое И
    }
}