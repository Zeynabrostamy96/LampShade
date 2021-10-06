using BlogManagment.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogManagement.Infrastructure.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(x => x.id);
            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.Picture).HasMaxLength(500);
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.MetaDesCription).HasMaxLength(150);
            builder.Property(x => x.KeyWords).HasMaxLength(100);
            builder.Property(x => x.Slug).HasMaxLength(60);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000);

            builder.HasMany(x => x.articles).WithOne(x => x.articleCategory).HasForeignKey(x => x.AricleCategoryId);
        }
    }
}
