using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsPortal.Data.Entities
{
    [Table("Articles")]
    public class ArticleEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }

        public virtual required CategoryEntity Category { get; set; }
    }
}
