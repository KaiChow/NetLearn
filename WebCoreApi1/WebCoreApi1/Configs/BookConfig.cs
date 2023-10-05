using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCoreApi1.Model;

namespace WebCoreApi1.Configs
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property<string>("Title").HasMaxLength(50).IsRequired();
            builder.Property<string>("AuthorName").HasMaxLength(50).IsRequired();

        }

    }
}
