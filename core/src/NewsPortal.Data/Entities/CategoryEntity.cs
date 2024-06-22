using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsPortal.Data.Entities
{
    [Table("Categories")]
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }

        public virtual ICollection<ArticleEntity>? Articles { get; set; }
    }
}
