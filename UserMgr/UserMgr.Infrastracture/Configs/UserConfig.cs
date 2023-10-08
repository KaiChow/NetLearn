using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMgr.Domain.Entities;

namespace UserMgr.Infrastracture.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.ToTable("T_Users");
            builder.OwnsOne(x => x.PhoneNumber, nb => { nb.Property(b => b.Number).HasMaxLength(20).IsUnicode(false); });
            builder.HasOne(b => b.UserAccessFail).WithOne(f => f.User).HasForeignKey<UserAccessFail>(f => f.UserId);
            builder.Property("PasswordHash").HasMaxLength(100).IsUnicode(false);
        }
    }
}
