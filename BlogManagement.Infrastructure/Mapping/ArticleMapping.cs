using BlogManagment.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(X => X.id);
            builder.Property(x => x.Title).HasMaxLength(500);
            builder.Property(x => x.ShortDescription).HasMaxLength(1000);
            builder.Property(x => x.Picture).HasMaxLength(500);
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.MetaDescription).HasMaxLength(150);
            builder.Property(x => x.KeyWords).HasMaxLength(100);
            builder.Property(x => x.Slug).HasMaxLength(60);
            builder.Property(x => x.CanonicalAddres).HasMaxLength(1000);


            builder.HasOne(x => x.articleCategory).WithMany(x => x.articles).HasForeignKey(x => x.AricleCategoryId);
        }
    }
}
