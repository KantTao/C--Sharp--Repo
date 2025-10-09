using BookManagementSystemAPI.Data;
using BookManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystemAPI.Repository;

public class BookRepository : IBookRepository
{
    
    
    private readonly BookDbContext _dbContext;

    public BookRepository(BookDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public Book CreateBook(Book book)
    {
        try
        {
            _dbContext.BookTable.Add(book);
            _dbContext.SaveChanges();
            return book;
        }
        catch (DbUpdateException dbex)
        {
            Console.WriteLine($"DB save error:{dbex.Message}");
            throw;
        }
        
        catch (Exception ex)
        {
            Console.WriteLine($"DB save error:{ex.Message}");
            throw;
        }
        return book;
    }

    public Book GetBookById(int id)
    {
        throw new NotImplementedException();
    }

    public Book GetBookBookByName(string name)
    {
        throw new NotImplementedException();
    }
}