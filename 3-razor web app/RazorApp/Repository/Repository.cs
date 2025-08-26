public class Repository : IRepository
{
    private readonly IDictionary<string, Book> books;

    public void AddBook(string isbn, string title, string author, DateTime publishedDate)
    {
        var book = new Book(isbn, title, author, publishedDate);
        books.Add(isbn, book);
    }

    public Book? GetBookByIsbn(string isbn)
    {
        return books.TryGetValue(isbn, out var book) ? book : null;
    }

    public List<Book> GetAllBooks()
    {
        return books.Values.ToList();
    }

    public bool DeleteBook(string isbn)
    {
        return books.Remove(isbn);
    }

    public Repository()
    {
        books = new Dictionary<string, Book>
        {
            { "978-3-16-148410-0", new Book("978-3-16-148410-0", "The Great Gatsby", "F. Scott Fitzgerald", new DateTime(1925, 4, 10)) },
            { "978-0-14-118263-6", new Book("978-0-14-118263-6", "1984", "George Orwell", new DateTime(1949, 6, 8)) },
            { "978-0-452-28423-4", new Book("978-0-452-28423-4", "To Kill a Mockingbird", "Harper Lee", new DateTime(1960, 7, 11)) },
            { "978-0-7432-7356-5", new Book("978-0-7432-7356-5", "The Da Vinci Code", "Dan Brown", new DateTime(2003, 3, 18)) }
        };
    }
}