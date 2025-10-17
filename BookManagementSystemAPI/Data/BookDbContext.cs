using BookManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using IdentityDbContext = Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext;

namespace BookManagementSystemAPI.Data
{
    
    
    public class BookDbContext:IdentityDbContext //Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext;
    {
        
        public DbSet<Book> BookTable { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<User> Users { get; set; }

        public BookDbContext(DbContextOptions<BookDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            
        }
        
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //define relation, define constraints
            //define data seeding
            modelBuilder.Entity<Book>().HasMany<Publisher>(x => x.Publishers);
            base.OnModelCreating(modelBuilder);
            
            
            // 自定义 User 表名（如果你不想用默认的 AspNetUsers）
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users"); // 改表名
                entity.Property(u => u.FullName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(u => u.LibraryReNo)
                    .HasMaxLength(50);
            });
            
            
            
        }
    }
}