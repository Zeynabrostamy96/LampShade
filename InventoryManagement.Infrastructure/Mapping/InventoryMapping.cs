

using InventoryManagment.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("inventory");
            builder.HasKey(x => x.id);

            builder.OwnsMany(x => x.inventoryOperations, ModelBuilder =>
            {
                ModelBuilder.ToTable("inventoryOperations");
                ModelBuilder.HasKey(x => x.id);

                ModelBuilder.Property(x => x.Description).HasMaxLength(1000);
                ModelBuilder.WithOwner(x => x.inventory).HasForeignKey(x => x.InventoryId);

            });


        }
    }
}
