using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>

    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {

            builder.ToTable(nameof(Account));

            builder.Property(s => s.AccountId);

            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);

            builder.Property(s => s.Age).IsRequired();

            builder.HasData(
                new Account { AccountId = Guid.NewGuid(), Name = "Kevin", Age = 24 },
                new Account { AccountId = Guid.NewGuid(), Name = "Alex", Age = 26 },
                new Account { AccountId = Guid.NewGuid(), Name = "Tommas", Age = 34 }
                );
        }
    }
}
