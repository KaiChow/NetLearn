using Microsoft.EntityFrameworkCore;
using WebCoreApi1.Model;

namespace WebCoreApi1.Entitys
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
    }
}
