using _0_Framwork.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        [Range(1,100000,ErrorMessage = ValidaionMessages.IsRequired)]
        public long CategoryId { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Title { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string ShortDescription { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Slug { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string PublishDate { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Keywords { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]
        public string MetaDescription { get; set; }
        public string CanonalAddress { get; set; }
    }
}
