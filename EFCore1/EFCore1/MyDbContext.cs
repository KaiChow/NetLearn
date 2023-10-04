using Microsoft.EntityFrameworkCore;

namespace EFCore1
{
    public class MyDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connStr = "Server=localhost;Database=SystemAdmin;Uid=sa;Pwd=zk123456;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connStr);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

    }
}
