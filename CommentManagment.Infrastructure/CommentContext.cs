using CommentManagment.Domain.CommentAgg;
using CommentManagment.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CommentManagment.Infrastructure
{
    public  class CommentContext:DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options):base(options)
        {

        }

        public DbSet<Comment>  comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            var assembly = typeof(CommentMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder); 
        }


    }
}
