using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommentManagement.Application.Contract.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServicesHost.Areas.Administration.Pages.Comments
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public CommentSearchModel SearchModel;
        public List<CommentViewModel> modelview { get; set; }

        private readonly ICommentApplication commentApplication;

        public IndexModel(ICommentApplication commentApplication)
        {
            this.commentApplication = commentApplication;
        }

        public void OnGet(CommentSearchModel model)
        {
            modelview = commentApplication.Search(model);
        }

        public IActionResult OnGetCancel(long Id)
        {
            var result = commentApplication.Cancel(Id);
            if (result.IsSucsseded)
            {
                return RedirectToPage("./Index");
            }
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetConfirm(long Id)
        {
            var result = commentApplication.Confirm(Id);
            if (result.IsSucsseded)
            {
                return RedirectToPage("./Index");
            }
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
