using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastracture.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentManagement.Infrastracture.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly CommentContext context;
        public CommentRepository(CommentContext db) : base(db)
        {
            context = db;
        }

        public List<CommentViewModel> Search(CommentSearchModel model)
        {
            var query = context.Comments
                .Select(s => new CommentViewModel
                {
                    Id=s.Id,
                    Email = s.Email,
                    IsCanceled = s.IsCanceled,
                    IsConfirmed = s.IsConfirmed,
                    Message = s.Message,
                    Name = s.Name,
                    Type = s.Type,
                    OwnerRecordId = s.OwnerRecordId,
                    WebSite=s.WebSite,
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
