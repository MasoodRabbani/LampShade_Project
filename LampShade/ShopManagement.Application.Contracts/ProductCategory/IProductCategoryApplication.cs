using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framwork.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        List<ProductCategoryViewModel> GetProductCategories();
        OprationResult Create(CreateProductCategory model);
        OprationResult Edit(EditProductCategory model);
        EditProductCategory GetDetails(long Id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel search);
    }
}
