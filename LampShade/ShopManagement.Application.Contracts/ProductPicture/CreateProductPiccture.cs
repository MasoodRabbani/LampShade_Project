using _0_Framwork.Application;
using ShopManagement.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPiccture
    {
        [Range(1,100000,ErrorMessage = ValidaionMessages.IsRequired)]
        public long ProductId { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]
        public string Picture { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string PictureTitle { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
