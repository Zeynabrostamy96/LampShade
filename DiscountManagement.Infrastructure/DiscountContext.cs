

using DiscountManagement.Infrastructure.Mapping;
using DiscountManagment.Domain.ColleagueDiscountAgg;
using DiscountManagment.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure
{
    public class DiscountContext:DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext>options):base(options)
        {

        }
        public DbSet<CustomerDiscount> customerDiscounts { get; set; }
        public DbSet<ColleagueDiscount> colleagueDiscounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder); 
        }
    }
}
