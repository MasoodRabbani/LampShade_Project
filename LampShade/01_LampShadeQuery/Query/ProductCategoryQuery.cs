using _01_LampShadeQuery.Contracts.ProductCategory;
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

        public ProductCategoryQuery(ShopContext context)
        {
            this.context = context;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return context.ProductCategories.Select(s => new ProductCategoryQueryModel
            {
                Name = s.Name,
                Picture = s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                Slug = s.Slug,
            }).ToList();
        }
    }
}
