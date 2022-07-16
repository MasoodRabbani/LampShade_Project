using _0_Framwork.Application;
using System.Collections.Generic;

namespace CommentManagement.Application.Contract.Comment
{
    public interface ICommentApplication
    {
        OprationResult Add(AddComment command);
        OprationResult Cancel(long Id);
        OprationResult Confirm(long Id);
        List<CommentViewModel> Search(CommentSearchModel model);

    }
}
