using _0_Framwork.Domain;
using CommentManagement.Domain.CommentAgg;
using System.Collections.Generic;

namespace CommentManagement.Domain.CommentAgg
{
    public class Comment:EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public string WebSite { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public long OwnerRecordId { get; private set; }
        public int Type { get; set; }
        public long ParentId { get; private set; }
        public Comment Parent { get; private set; }
        public List<Comment> Children { get; private set; }

        public Comment(string name, string email, string message, string webSite, long ownerRecordId, int type, long parentId)
        {
            Name = name;
            Email = email;
            Message = message;
            WebSite = webSite;
            OwnerRecordId = ownerRecordId;
            Type = type;
            ParentId = parentId;
        }

        public void Confirm() { this.IsConfirmed = true; this.IsCanceled = false; }
        public void Cancel() { this.IsCanceled = true; this.IsConfirmed = false; }
    }
}
