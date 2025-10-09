using BookManagementSystemAPI.Models;

namespace BookManagementSystemAPI.Services;

public interface IBookService
{
    Book CreateBook(BookCreateRequest bookCreateRequest);
    Book GetBookById(int id);
    Book GetBookBookByName(string name);
    
}