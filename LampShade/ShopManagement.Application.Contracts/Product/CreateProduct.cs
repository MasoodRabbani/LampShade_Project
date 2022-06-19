using _0_Framwork.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]
        public string Name { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Code { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]
         public string Description { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string ShortDescription { get; set; }

        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Slug { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string Keywords { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string MetaDescription { get; set; }
        [Range(0,100000,ErrorMessage = ValidaionMessages.IsRequired)]
        public long CategoryId { get; set; }
        public List<ProductCategory.ProductCategoryViewModel> Categoris { get; set; }
    }
}
