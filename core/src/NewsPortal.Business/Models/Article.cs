namespace NewsPortal.Business.Models
{
    public class Article
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int CategoryId { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public required Category Category { get; set; }
    }
}
