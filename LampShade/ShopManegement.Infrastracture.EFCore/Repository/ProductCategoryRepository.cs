using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framwork.Domain;
using _0_Framwork.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManegement.Infrastracture.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory>,IProductCategoryRepository
    {
        private readonly ShopContext db;

        public ProductCategoryRepository(ShopContext db):base(db)
        {
            this.db = db;
        }

        public EditProductCategory GetDetails(long id)
        {
            return db.ProductCategories.Select(s => new EditProductCategory
            {
                Id = s.Id,
                Description = s.Description,
                Keywords = s.Keywords,
                MetaDescription = s.MetaDescription,
                Name = s.Name,
                Picture = s.Picture,
                PictureTitle = s.PictureTitle,
                PictureAlt = s.PictureAlt
            }).FirstOrDefault(s => s.Id == id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return db.ProductCategories.Select(s => new ProductCategoryViewModel()
            {
                Id = s.Id,
                Name = s.Name,
            }).ToList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel command)
        {
            var query = db.ProductCategories.Select(s => new ProductCategoryViewModel
            {
                Name = s.Name,
                Id = s.Id,
                CreationDate = s.CreationDate.ToString(),
                Picture = s.Picture,

            });
            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                query = query.Where(s=>s.Name.Contains(command.Name));
            }

            return query.OrderByDescending(s=>s.Id).ToList();
        }
    }
}
