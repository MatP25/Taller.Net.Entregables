
using System;
using System.ComponentModel.DataAnnotations;
public class Book
{
    public int Id { get; set; }
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    [DataType(DataType.Date)]
    public DateTime PublishedDate { get; set; }

    public Book(int id, string isbn, string title, string author, DateTime publishedDate)
    {
        Id = id;
        Isbn = isbn;
        Title = title;
        Author = author;
        PublishedDate = publishedDate;
    }
    public Book() { }
}