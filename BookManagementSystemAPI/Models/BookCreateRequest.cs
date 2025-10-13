namespace BookManagementSystemAPI.Models
{
    
    public class BookCreateRequest
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
    }
}
