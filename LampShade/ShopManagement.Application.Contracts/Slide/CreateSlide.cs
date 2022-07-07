using _0_Framwork.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slide
{
    public class CreateSlide
    {

        public IFormFile Picture { get;  set; }
        [Required(ErrorMessage =ValidaionMessages.IsRequired)]
        public string PictureAlt { get;  set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string PictureTitle { get;  set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Heading { get;  set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Title { get;  set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Text { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Link { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string BtnText { get;  set; }
    }
}
