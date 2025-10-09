namespace BookManagementSystemAPI.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //navigation property
        //N to N relation to Book
        public List<Book> Books { get; set; }

        public Publisher(int id, string name)
        {
            Id = id;
            Name = name;
            Books = new List<Book>();
        }
    }
}
