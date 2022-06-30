using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framwork.Application;
using ShopManagement.Application.Contracts.Product;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class CreateInventory
    {
        [Range(1,100000,ErrorMessage =ValidaionMessages.IsRequired)]
        public long ProductId { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = ValidaionMessages.IsRequired)]

        public double UnitPrice { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
