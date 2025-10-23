using BookManagementSystemAPI.Data;
using BookManagementSystemAPI.Models;
using BookManagementSystemAPI.MongoCollection;
using BookManagementSystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        
        private BookDbContext _dbContext;
        private readonly IBookService _bookService;
        private readonly MongoDbContext _mongoDbContext;
        
        
        public BookController(IBookService _bookService,MongoDbContext mongoDbContext)
        {
            this._bookService = _bookService;
            _mongoDbContext = mongoDbContext;
        }

        // [HttpGet]
        // public IActionResult GetBooks()
        // {
        //     //加载book 数据时， 使用include 同时加载author, 这个叫eager loading
        //     //会出现无限reference 的错误
        //     //因为author 里有book, book里有author
        //     List<Book> books = _dbContext.Books.Include(x=>x.Author).ToList();
        //     return Ok(books);
        // }

        // [HttpGet("{name}")]
        // public IActionResult GetBookByName(string name)
        // {
        //     List<Book> matchedBooks = _dbContext.Books.Where(x => x.Name == name).ToList();
        //     return Ok(matchedBooks);
        // }

        
        
        [HttpPost]
        //Model binding
        //json format to pass the model from client side to backend api
        //  { 
        //      "Name":"nice book",
        //      "description":"test"
        //
        //   }
        
        
        //DTO 
        public IActionResult CreateBook([FromBody] BookCreateRequest book)
        {
            Book newBook = _bookService.CreateBook(book); //SQL server的数据床架
            var bookEvent = new BookEvent
            {
                BookId = newBook.Id,
                AuthorId = newBook.AuthorId, 
                EventNote = $"Book '{newBook.Name}' created successfully at {DateTime.UtcNow}"
                
            };
            
            _mongoDbContext.BookEvents.InsertOne(bookEvent); //依赖注入
            return StatusCode(201, newBook);

        }
        
        
        
        // [HttpGet]
        // [Route("GetBookByDescription")]
        // public IActionResult GetBookByDescription([FromQuery] string description)
        // {
        //     List<Book> matchedBooks = _dbContext.Books.Where(x => x.Description == description).ToList();
        //     return Ok(matchedBooks);
        // }
    }
}
