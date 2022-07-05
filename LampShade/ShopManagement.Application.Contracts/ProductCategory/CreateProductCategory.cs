using _0_Framwork.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]
        public string Name { get;  set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Description { get;  set; }
        [FileExtentionLimitation(new string[] {".jpeg",".png",".jpg"},ErrorMessage =ValidaionMessages.InvalidFileExtention)]
        [MaxFileSize(3*1024*1024, ErrorMessage = ValidaionMessages.MaxFileSize)]
        public IFormFile Picture { get;  set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string PictureAlt { get;  set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string PictureTitle { get;  set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Keywords { get;  set; }
        public string MetaDescription { get;  set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Slug { get; set; }
    }
}
