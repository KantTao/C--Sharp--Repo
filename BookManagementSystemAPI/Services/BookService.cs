using BookManagementSystemAPI.Models;
using BookManagementSystemAPI.Repository;

namespace BookManagementSystemAPI.Services;


public class BookService : IBookService
{   
    
    private readonly IBookRepository _bookRepository;
    //把接口作为构造函数参数  依赖注入
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    
    //DTO 传输 
    public Book CreateBook(BookCreateRequest bookCreateRequest)
    {
        //DTO 转变为 实体Book
        Book newBook = new Book(bookCreateRequest.Name, bookCreateRequest.Description, bookCreateRequest.AuthorId);
        if (newBook.Id > 0)
        { 
            throw new ArgumentException($"Book Id is invalid,value:{newBook.Id}");
        }
        
        if (!string.IsNullOrWhiteSpace(newBook.Name) && !string.IsNullOrWhiteSpace(newBook.Description))
        {
            Book book = _bookRepository.CreateBook(newBook);
            return book;
        }
        throw new ArgumentException("Book name or description can be null or empty");
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