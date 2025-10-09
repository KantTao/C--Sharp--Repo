using BookManagementSystemAPI.Models;

namespace BookManagementSystemAPI.Repository;


public interface IBookRepository
{
    Book CreateBook(Book book);
    Book GetBookById(int id);
    Book GetBookBookByName(string name);
}