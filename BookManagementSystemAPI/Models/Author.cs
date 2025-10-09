using System.ComponentModel.DataAnnotations;

namespace BookManagementSystemAPI.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        //related entities, 
        //Navigation properties
        // author.Books related books data
        // JOIN LEFT JOIN RIGHT JOIN INNER JOIN
        //ORM one of the best features
        public List<Book> Books { get; set; }

        public Author(int id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Books = new List<Book>();
        }
    }
}
