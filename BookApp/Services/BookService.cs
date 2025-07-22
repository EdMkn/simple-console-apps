using BookApp.Models;

namespace BookApp.Services;

public class BookService
{
    private readonly List<Book> _books = new()
    {
        new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 },
        new Book { Id = 2, Title = "Le Petit Prince", Author = "Antoine de Saint-Exupéry", Year = 1943 }
    };

    public IEnumerable<Book> GetAll() => _books;

    public Book? Get(int id) => _books.FirstOrDefault(b => b.Id == id);

    public Book Create(Book book)
    {
        book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
        _books.Add(book);
        return book;
    }

    public bool Update(int id, Book book)
    {
        var existing = Get(id);
        if (existing == null) return false;

        existing.Title = book.Title;
        existing.Author = book.Author;
        existing.Year = book.Year;
        return true;
    }

    public bool Delete(int id)
    {
        var book = Get(id);
        if (book == null) return false;

        _books.Remove(book);
        return true;
    }
}
