using _0_Framwork.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage =ValidaionMessages.IsRequired)]
        public string Name { get;set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public IFormFile Picture { get;set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Description { get;set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public int ShowOrder { get;set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Slug { get;set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Keywords { get;set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string MetaDescription { get;set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string CanonicalAddress { get;set; }
    }
}
