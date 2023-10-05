using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCoreApi1.Model;

namespace WebCoreApi1.Configs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne<Article>(c=>c.TheArticle).WithMany(a=>a.Comments).IsRequired();
            builder.Property(c=>c.Message).IsRequired().IsUnicode();
            
        }
    }
    
}
