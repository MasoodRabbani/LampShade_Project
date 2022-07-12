using _01_LampShadeQuery.Contracts.Article;
using _01_LampShadeQuery.Contracts.ArticleCategory;
using _01_LampShadeQuery.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery
{
    public class MenuModel
    {
        public List<ArticleCategoryQueryModel> ArticleCategoryQueries { get; set; }
        public List<ProductCategoryQueryModel> ProductCategoryQueries { get; set; }
    }
}
