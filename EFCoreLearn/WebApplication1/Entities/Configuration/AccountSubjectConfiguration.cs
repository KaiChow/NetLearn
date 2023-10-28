using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication1.Entities.Configuration
{
    public class AccountSubjectConfiguration : IEntityTypeConfiguration<AccountSubject>
    {
        public void Configure(EntityTypeBuilder<AccountSubject> builder)
        {
            
        }
    }
}
