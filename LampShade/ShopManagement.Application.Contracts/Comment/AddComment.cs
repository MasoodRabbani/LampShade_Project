using _0_Framwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Comment
{
    public class AddComment
    {
        public string Name { get;   set; }
        public string Email { get;  set; }
        public string Message { get;  set; }
        public long ProductId { get;  set; }
    }
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCanceled { get; set; }
        public string CommentDate { get; set; }
    }
    public class CommentSearchModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public interface ICommentApplication
    {
        OprationResult Add(AddComment command);
        OprationResult Cancel(long Id);
        OprationResult Confirm(long Id);
        List<CommentViewModel> Search(CommentSearchModel model);

    }
}
