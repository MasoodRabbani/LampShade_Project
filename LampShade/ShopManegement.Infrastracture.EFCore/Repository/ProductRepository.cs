using _0_Framwork.Application;
using _0_Framwork.Domain;
using _0_Framwork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ShopManegement.Infrastracture.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext context;
        public ProductRepository(ShopContext db) : base(db)
        {
            context = db;
        }

        public EditProduct GetDetails(long id)
        {
            var s=context.Products.FirstOrDefault(p => p.Id == id);
            return new EditProduct
            {
                Id = id,
                Name = s.Name,
                CategoryId = s.CategoryId,
                Code = s.Code,
                Description = s.Description,
                Keywords = s.Keywords,
                MetaDescription = s.MetaDescription,
                //Picture=s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                ShortDescription = s.ShortDescription,
                Slug = s.Slug,
            };
        }

        public List<ProductViewModel> GetProducts()
        {
            var result= context.Products.Select(s=>new ProductViewModel
            {
                Id = s.Id,
                Name = s.Name,
                
            }).ToList();
            return result;
        }

        public Product GetProductWithCategory(long id)
        {
            return context.Products.Include(s=>s.ProductCategory).FirstOrDefault(p => p.Id == id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = context.Products.Include(s => s.ProductCategory).Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Picture = p.Picture,
                Category = p.ProductCategory.Name,
                Code = p.Code,
                CategoryId=p.CategoryId,
                CreationDate=p.CreationDate.ToFarsi(),
                
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query=query.Where(s => s.Name.Contains(searchModel.Name));
            }if (!string.IsNullOrWhiteSpace(searchModel.Code))
            {
                query=query.Where(s => s.Code.Contains(searchModel.Code));
            }if (searchModel.CategoryId!=0)
            {
                query=query.Where(s => s.CategoryId==searchModel.CategoryId);
            }
            return query.OrderByDescending(s => s.Id).ToList();
        }
    }
}
