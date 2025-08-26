
using System;
public class Book
{
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime PublishedDate { get; set; }

    public Book(string isbn, string title, string author, DateTime publishedDate)
    {
        Isbn = isbn;
        Title = title;
        Author = author;
        PublishedDate = publishedDate;
    }
}