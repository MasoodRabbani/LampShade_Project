using _0_Framwork.Application;
using ShopManagement.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        [Range(1,10000,ErrorMessage = ValidaionMessages.IsRequired)]
        public long ProductId { get; set; }
        [Range(1, 99, ErrorMessage = ValidaionMessages.IsRequired)]

        public int DiscountRate { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]
        public string StartDate { get; set; }
        [Required(ErrorMessage = ValidaionMessages.IsRequired)]

        public string EndDate { get; set; }
        public string Reason { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
