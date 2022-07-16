using CommentManagement.Application.Contract.Comment;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastracture.EfCore;
using CommentManagement.Infrastracture.EFCore.Repository;
using CommentManagment.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CommentManagement.Configuration
{
    public class CommentManagementBootstrapper
    {
        public static void Configuration(IServiceCollection service,string connectingstring)
        {
            service.AddTransient<ICommentRepository, CommentRepository>();
            service.AddTransient<ICommentApplication, CommentApplication>();


            service.AddDbContext<CommentContext>(s => s.UseSqlServer(connectingstring));
        }
    }
}
