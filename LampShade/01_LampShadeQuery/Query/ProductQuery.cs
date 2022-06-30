using _0_Framwork.Application;
using _01_LampShadeQuery.Contracts.Product;
using DiscountManagement.Infrastracture.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManegement.Infrastracture.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext shopContext;
        private readonly InventoryContext inventoryContext;
        private readonly DiscountContext discountContext;

        public ProductQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            this.shopContext = shopContext;
            this.inventoryContext = inventoryContext;
            this.discountContext = discountContext;
        }

        public List<ProductQueryModel> GetLatestArrivals()
        {
            var product = shopContext.Products.Include(s => s.ProductCategory)
                .Select(s => new ProductQueryModel
                {
                    Id = s.Id,
                    Category = s.ProductCategory.Name,
                    Name = s.Name,
                    Picture = s.Picture,
                    PictureAlt = s.PictureAlt,
                    PictureTitle = s.PictureTitle,
                    Sluge = s.Slug,
                }).OrderByDescending(s=>s.Id).Take(6).ToList();
            foreach (var item in product)
            {
                var price = inventoryContext.Inventories.FirstOrDefault(s => s.ProductId == item.Id)?.UnitPrice;
                if (price != null)
                {
                    item.Price = price.Value.ToMoney();
                    if (discountContext.CustomerDiscounts.Any(s => s.ProductId == item.Id))
                    {
                        var DiscountRate = discountContext.CustomerDiscounts.FirstOrDefault(s => s.ProductId == item.Id).DiscountRate;
                        item.DiscountRate = DiscountRate;
                        item.HasDiscount = item.DiscountRate > 0;
                        var discoutamount = Math.Round((price.Value * DiscountRate) / 100);
                        item.PriceWithDiscount = (price.Value - discoutamount).ToMoney();
                    }
                }
            }




            return product;
        }
    }
}
