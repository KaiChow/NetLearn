using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCoreApi1.Model;

namespace WebCoreApi1.Configs
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("T_Books");
            builder.Property<string>("Title").HasMaxLength(50).IsRequired();
        }

    }
}
