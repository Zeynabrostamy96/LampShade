using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagment.Infrastructure.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");
            builder.HasKey(x => x.id);
            builder.Property(x => x.Name).HasMaxLength(500).IsRequired();

            builder.HasMany(x => x.accounts).WithOne(x => x.role).HasForeignKey(x => x.RoleId);

            builder.OwnsMany(x => x.Permissions, ModelBuilder =>
            {

                ModelBuilder.ToTable("permission");
                ModelBuilder.HasKey(x => x.Id);
                ModelBuilder.Property(x => x.Name).HasMaxLength(500);
                ModelBuilder.WithOwner(x => x.role).HasForeignKey(x => x.RoleId);

            });

        }
    }
}
