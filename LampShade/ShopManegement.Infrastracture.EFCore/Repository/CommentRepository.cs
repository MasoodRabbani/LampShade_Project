using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Comment;
using ShopManagement.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.Infrastracture.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly ShopContext context;
        public CommentRepository(ShopContext db) : base(db)
        {
            context = db;
        }

        public List<CommentViewModel> Search(CommentSearchModel model)
        {
            var query = context.Comments.Include(s => s.Product)
                .Select(s => new CommentViewModel
                {
                    Id=s.Id,
                    Email = s.Email,
                    IsCanceled = s.IsCanceled,
                    IsConfirmed = s.IsConfirmed,
                    Message = s.Message,
                    Name = s.Name,
                    ProductId = s.ProductId,
                    ProductName = s.Product.Name,
                    CommentDate = s.CreationDate.ToFarsi()
                });
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                query = query.Where(s => s.Name.Contains(model.Name));
            }
            if (!string.IsNullOrWhiteSpace(model.Email))
            {
                query=query.Where(s => s.Email.Contains(model.Email));
            }
            return query.OrderByDescending(s=>s.Id).ToList();
        }
    }
}
