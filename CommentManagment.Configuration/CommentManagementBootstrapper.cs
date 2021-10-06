using CommentManagment.Application.Comment;
using CommentManagment.Application.Contracts.Comment;
using CommentManagment.Domain.CommentAgg;
using CommentManagment.Infrastructure;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManagment.Configuration
{
    public class CommentManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICommentApplication, CommentApplication>();

            services.AddDbContext<CommentContext>(x=>x.UseSqlServer(connectionString));
        }

    }
}
