using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication1.Entities.Configuration;

namespace WebApplication1.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 配置懒加载
            optionsBuilder.UseLazyLoadingProxies();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 一个一个手动配置
            //modelBuilder.ApplyConfiguration(new AccountConfiguration());
            // 自动扫描程序集,所有实现 IEntityTypeConfiguration接口的类
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
