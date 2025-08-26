public interface IRepository
{
    public void AddBook(string isbn, string title, string author, DateTime publishedDate);
    public Book? GetBookByIsbn(string isbn);
    public List<Book> GetAllBooks();
    public bool DeleteBook(string isbn);
}