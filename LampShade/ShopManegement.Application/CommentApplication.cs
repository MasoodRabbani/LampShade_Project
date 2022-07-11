using _0_Framwork.Application;
using ShopManagement.Application.Contracts.Comment;
using ShopManagement.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public OprationResult Add(AddComment command)
        {
            OprationResult oprationresult = new OprationResult();
            var comment = new Comment(command.Name,command.Email,command.Message,command.ProductId);
            commentRepository.Create(comment);
            commentRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public OprationResult Cancel(long Id)
        {
            OprationResult result = new OprationResult();
            var comment=commentRepository.Get(Id);
            if (comment == null)
                return result.Feiled(ApplicationMessages.RecordNotFound);
            comment.Cancel();
            commentRepository.SaveChanges();
            return result.Sucsseded();
        }

        public OprationResult Confirm(long Id)
        {
            OprationResult result = new OprationResult();
            var comment = commentRepository.Get(Id);
            if (comment == null)
                return result.Feiled(ApplicationMessages.RecordNotFound);
            comment.Confirm();
            commentRepository.SaveChanges();
            return result.Sucsseded();
        }

        public List<CommentViewModel> Search(CommentSearchModel model)
        {
            return commentRepository.Search(model);
        }
    }
}
