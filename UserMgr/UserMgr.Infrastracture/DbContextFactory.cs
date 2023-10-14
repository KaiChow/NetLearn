using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserMgr.Infrastracture
{
    // 数据库迁移 
    public class DbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<UserDbContext>();
            builder.UseSqlServer("Server=localhost;Database=SystemAdmin;User Id=sa;Password=zk123456;");
            return new UserDbContext(builder.Options);
        }
    }
}
