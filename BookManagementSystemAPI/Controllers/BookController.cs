using BookManagementSystemAPI.Data;
using BookManagementSystemAPI.Models;
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
        
        public BookController(IBookService _bookService)
        {
            this._bookService = _bookService;
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
            
            Book newBook = _bookService.CreateBook(book);
           // return Ok(newBook);
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
