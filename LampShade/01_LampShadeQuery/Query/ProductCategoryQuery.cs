using _0_Framwork.Application;
using _01_LampShadeQuery.Contracts.Product;
using _01_LampShadeQuery.Contracts.ProductCategory;
using DiscountManagement.Infrastracture.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManegement.Infrastracture.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext context;
        private readonly InventoryContext inventoryContext;
        private readonly DiscountContext discountContext;

        public ProductCategoryQuery(ShopContext context, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            this.context = context;
            this.inventoryContext = inventoryContext;
            this.discountContext = discountContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return context.ProductCategories.Select(s => new ProductCategoryQueryModel
            {
                Id = s.Id,  
                Name = s.Name,
                Picture = s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                Slug = s.Slug,
            }).AsNoTracking().ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
        {
            var inventory = inventoryContext.Inventories.Select(s => new { s.ProductId, s.UnitPrice }).ToList();
            var discount = discountContext.CustomerDiscounts
                .Where(s=>s.StartDate<DateTime.Now&&s.EndDate>DateTime.Now)
                .Select(s => new { s.ProductId, s.DiscountRate }).ToList();
            var category= context.ProductCategories
                .Include(s => s.Products)
                .ThenInclude(s => s.ProductCategory)
                .Select(s => new ProductCategoryQueryModel
            {
                Id = s.Id,
                Products = MapProducts(s.Products),
                Name = s.Name,
            }).AsNoTracking().ToList();
            foreach (var subcat in category)
            {
                foreach (var item in subcat.Products)
                {
                    var price = inventory.FirstOrDefault(s => s.ProductId == item.Id)?.UnitPrice;
                    if (price!=null)
                    {
                        item.Price = price.Value.ToMoney();
                    }
                    if (discount.Any(s=>s.ProductId==item.Id))
                    {
                        var DiscountRate = discount.FirstOrDefault(s => s.ProductId == item.Id).DiscountRate;
                        item.DiscountRate = DiscountRate;
                        item.HasDiscount = item.DiscountRate > 0;
                        var discoutamount = Math.Round((price.Value * DiscountRate) / 100);
                        item.PriceWithDiscount = (price.Value - discoutamount).ToMoney();
                    }
                    
                }
            }
            return category;
        }

        private static List<ProductQueryModel> MapProducts(List<Product> products)
        {
            return products.Select(s => new ProductQueryModel
            {
                Id = s.Id,
                Category = s.ProductCategory.Name,
                Name = s.Name,
                Picture = s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                Sluge = s.Slug,
            }).ToList();
            //return products.Select(s => new ProductQueryModel
            //{
            //    Id = s.Id,
            //    Category=s.ProductCategory.Name,
            //    Name=s.Name,
            //    Picture=s.Picture,
            //    PictureAlt=s.PictureAlt,
            //    PictureTitle=s.PictureTitle,
            //    Sluge=s.Slug,


            //}).OrderByDescending(s=>s.Id).ToList();
        }

        public ProductCategoryQueryModel GetProductCategoryWithProductsBy(string slug)
        {
            var inventory = inventoryContext.Inventories.Select(s => new { s.ProductId, s.UnitPrice }).ToList();
            var discount = discountContext.CustomerDiscounts
                .Where(s => s.StartDate < DateTime.Now && s.EndDate > DateTime.Now)
                .Select(s => new { s.ProductId, s.DiscountRate ,s.EndDate}).ToList();
            var category = context.ProductCategories
                .Include(s => s.Products)
                .ThenInclude(s => s.ProductCategory)
                .Select(s => new ProductCategoryQueryModel
                {
                    Id = s.Id,
                    Products = MapProducts(s.Products),
                    Name = s.Name,
                    Description = s.Description,
                    MetaDescription= s.MetaDescription,
                    Slug = s.Slug,
                    Keyword=s.Keywords
                }).AsNoTracking().FirstOrDefault(s=>s.Slug==slug);
                foreach (var item in category.Products)
                {
                    var price = inventory.FirstOrDefault(s => s.ProductId == item.Id)?.UnitPrice;
                if (price != null)
                {
                    item.Price = price.Value.ToMoney();
                    var Discount = discount.FirstOrDefault(s => s.ProductId == item.Id);
                    if (Discount!=null)
                    {
                        int DiscountRate = Discount.DiscountRate;
                        item.DiscountRate = DiscountRate;
                        item.DiscountExpireDate = Discount.EndDate.ToDiscountFormat();
                        item.HasDiscount = item.DiscountRate > 0;
                        var discoutamount = Math.Round((price.Value * DiscountRate) / 100);
                        item.PriceWithDiscount = (price.Value - discoutamount).ToMoney();
                    }
                }
                }
            return category;
        }
    }
}
