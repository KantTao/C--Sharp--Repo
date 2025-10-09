using BookManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystemAPI.Data
{
    
    
    
    
    public class BookDbContext:DbContext //BookDb database
    {
        public DbSet<Book> BookTable { get; set; }
        public DbSet<Author> Authors { get; set; }
        public BookDbContext(DbContextOptions<BookDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //define relation, define constraints
            //define data seeding
            modelBuilder.Entity<Book>().HasMany<Publisher>(x => x.Publishers);



            base.OnModelCreating(modelBuilder); 
        }
    }
}
