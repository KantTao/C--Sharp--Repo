using System.ComponentModel.DataAnnotations;
using BookManagementSystemAPI.Models;

public class Author
{
    [Key] public int Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] public DateTime DateOfBirth { get; set; }

    public List<Book> Books { get; set; }

    public Author(int id, string name, DateTime dateOfBirth)
    {
        Id = id;
        Name = name;
        DateOfBirth = dateOfBirth;
        Books = new List<Book>();
    }
    
}
