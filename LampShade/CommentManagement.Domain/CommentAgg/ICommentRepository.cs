using _0_Framwork.Domain;
using CommentManagement.Application.Contract.Comment;
using System.Collections.Generic;

namespace CommentManagement.Domain.CommentAgg
{
    public interface ICommentRepository:IRepository<long,Comment>
    {

        List<CommentViewModel> Search(CommentSearchModel model);
    }
}
