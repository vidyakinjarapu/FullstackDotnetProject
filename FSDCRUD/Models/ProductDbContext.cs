using Microsoft.EntityFrameworkCore;
namespace FSDCRUD.Models
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Models.Product> Products { get; set; }
    }
}
