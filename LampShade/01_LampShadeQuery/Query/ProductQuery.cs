using _0_Framwork.Application;
using _01_LampShadeQuery.Contracts.Comment;
using _01_LampShadeQuery.Contracts.Product;
using CommentManagement.Infrastracture.EfCore;
using DiscountManagement.Infrastracture.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.ProductPictureAgg;
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
        private readonly CommentContext commentContext;

        public ProductQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext, CommentContext commentContext)
        {
            this.shopContext = shopContext;
            this.inventoryContext = inventoryContext;
            this.discountContext = discountContext;
            this.commentContext = commentContext;
        }

        public ProductQueryModel GetDetails(string slug)
        {
            var product = shopContext.Products
                .Include(s => s.ProductCategory)
                .Select(s => new ProductQueryModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Category = s.ProductCategory.Name,
                    Picture = s.Picture,
                    PictureAlt = s.PictureAlt,
                    PictureTitle = s.PictureTitle,
                    ShortDescription = s.ShortDescription,
                    MetaDescription = s.MetaDescription,
                    Code = s.Code,
                    KeyWords = s.Keywords,
                    Description = s.Description,
                    Pictures = MapProductPicture(s.ProductPictures),
                    Sluge = s.Slug,
                }).FirstOrDefault(s => s.Sluge == slug);
            var inventory = inventoryContext.Inventories.Select(s => new { s.ProductId, s.UnitPrice ,s.IsStock}).FirstOrDefault(s => s.ProductId == product.Id);
            var discount = discountContext.CustomerDiscounts
                .Where(s => s.StartDate < DateTime.Now && s.EndDate > DateTime.Now)
                .Select(s => new { s.ProductId, s.DiscountRate, s.EndDate })
                .FirstOrDefault(s => s.ProductId == product.Id);
            if (inventory!=null)
            {
                product.IsInStack = inventory.IsStock;
                product.Price = inventory.UnitPrice.ToMoney();
                product.DoublePrice = inventory.UnitPrice;
                if (discount!=null)
                {
                    product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                    product.DiscountRate = discount.DiscountRate;
                    product.HasDiscount = product.DiscountRate > 0;
                    var discoutamount = Math.Round((inventory.UnitPrice * discount.DiscountRate) / 100);
                    product.PriceWithDiscount = (inventory.UnitPrice- discoutamount).ToMoney();
                }

            }
            product.Comments=commentContext.Comments
                .Where(s=>s.Type==CommentType.Product)
                .Where(s=>s.OwnerRecordId==product.Id)
                .Where(s=>!s.IsCanceled&&s.IsConfirmed)
                .Select(s=>new CommentQueryModel
                {
                    Id = s.Id,
                    Message = s.Message,
                    Name=s.Name
                }).OrderByDescending(s=>s.Id).ToList();
            return product;
                

        }

        private static List<ProductPictureQueryModel> MapProductPicture(List<ProductPicture> productPictures)
        {
            return productPictures.Select(s => new ProductPictureQueryModel
            {
                ProductId = s.ProductId,
                Picture = s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle
            }).ToList();
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

        public List<ProductQueryModel> Search(string value)
        {
            var inventory = inventoryContext.Inventories.Select(s => new { s.ProductId, s.UnitPrice }).ToList();
            var discount = discountContext.CustomerDiscounts
                .Where(s => s.StartDate < DateTime.Now && s.EndDate > DateTime.Now)
                .Select(s => new { s.ProductId, s.DiscountRate, s.EndDate }).ToList();
            var query = shopContext.Products
                .Include(s => s.ProductCategory)
                .Select(s => new ProductQueryModel
                {
                    Id = s.Id,
                    Category=s.ProductCategory.Name,
                    Picture=s.Picture,
                    PictureAlt=s.PictureAlt,
                    PictureTitle=s.PictureTitle,
                    CategorySlug=s.ProductCategory.Slug,
                    Name = s.Name,
                    ShortDescription=s.ShortDescription,
                    Sluge = s.Slug,
                }).AsNoTracking();
            if (!string.IsNullOrWhiteSpace(value))
            {
                query=query.Where(s=>s.Name.Contains(value)||s.ShortDescription.Contains(value));
            }
            var products = query.OrderByDescending(s => s.Id).ToList();
            foreach (var item in products)
            {
                var price = inventory.FirstOrDefault(s => s.ProductId == item.Id)?.UnitPrice;
                if (price != null)
                {
                    item.Price = price.Value.ToMoney();
                    var Discount = discount.FirstOrDefault(s => s.ProductId == item.Id);
                    if (Discount != null)
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
            return products;
        }

        public List<CartItems> CheackInventoryStatus(List<CartItems> items)
        {
            var inventory=inventoryContext.Inventories.ToList();
            foreach (var i in items.Where(s=>inventory.Any(g=>g.ProductId==s.Id&&g.IsStock)))
            {
                var inventoryitem=inventory.FirstOrDefault(s=>s.ProductId==i.Id);
                if (inventoryitem!=null)
                {
                    i.IsInStack = inventoryitem.CalculateInventoryStock() >= i.Count;
                }
            }
            return items;
        }
    }
}
