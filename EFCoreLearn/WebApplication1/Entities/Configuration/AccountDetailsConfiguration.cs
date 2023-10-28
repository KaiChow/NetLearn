using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configuration
{
    public class AccountDetailsConfiguration : IEntityTypeConfiguration<AccountDetails>
    {
        public void Configure(EntityTypeBuilder<AccountDetails> builder)
        {
            builder.ToTable(nameof(AccountDetails));

            builder.Property(s => s.Id).HasColumnName("AccountDetailsId");
        }
    }
}
