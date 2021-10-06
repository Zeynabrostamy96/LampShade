using InventoryManagement.Infrastructure.Mapping;
using InventoryManagment.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;


namespace InventoryManagement.Infrastructure
{
    public class InventoryContext:DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options):base(options)
        {

        }
        public DbSet<Inventory> inventory{ get; set; }
        public DbSet<InventoryOperation> inventoryOperations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder); 
        }
    }
}
