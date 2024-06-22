using Microsoft.EntityFrameworkCore;
using NewsPortal.Data.Entities;

namespace NewsPortal.Data
{
    public class NewsPortalDbContext : DbContext
    {
        public NewsPortalDbContext(DbContextOptions<NewsPortalDbContext> options) : base(options)
        {

        }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ArticleEntity> Articles { get; set; }
    }
}
