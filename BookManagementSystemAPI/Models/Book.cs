using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagementSystemAPI.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        //Convention based 约束驱动也是代码
        //通过命名上的规范和一致性， 我们可以让EF 自动生成相关约束！
        //EF, SPRINGBOOT 
        //[EntityId]
        //这一行会生成新的Column, Foreign key
        //[ForeignKey("Author")]
        //[Required]
        public int AuthorId { get; set; }
        
        //自动加载关联数据 , ORM feature
        //不然的话 你得一堆SQL JOIN
        //NP, navigation property, EF 
        //不会生成实际的Column, 就是代表和别的表的关系
        public Author Author { get; set; }

        //N to N relation to Publisher
        public List<Publisher> Publishers { get; set; }
        
        public Book(string name, string description, int authorId)
        {
            Name = name;
            Description = description;
            AuthorId = authorId;
        }
    }
}
