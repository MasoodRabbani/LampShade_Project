using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using _0_Framework.Application;
using _0_Framwork.Application;

namespace ShopManegement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }
        public OprationResult Create(CreateProductCategory model)
        {
            var operationres = new OprationResult();
            if (productCategoryRepository.Exists(s=>s.Name==model.Name))
                return operationres.Feiled("امکان ثبت رکورد تکراری وجود ندارد لطفا مجدد تلاش بفرمایید.");
            var slug = model.Slug.Slugify();
            var productcategory = new ProductCategory(model.Name, model.Description, model.Picture, model.PictureAlt,
                model.PictureTitle, model.Keywords, model.MetaDescription, slug);
            productCategoryRepository.Create(productcategory);
            productCategoryRepository.SaveChanges();
            return operationres.Sucsseded();
        }

        public OprationResult Edit(EditProductCategory model)
        {
            var opration = new OprationResult();
            var productcategory = productCategoryRepository.Get(model.Id);
            if (productcategory==null)
                return opration.Feiled("رکورد با اطلاعات درخاست شده یافت نشد لطفا مجدد تلاش بفرمایید.");
            if (productCategoryRepository.Exists(s => s.Name == model.Name && s.Id != model.Id))
                return opration.Feiled("رکورد با اطلاعات درخاست شده یافت نشد لطفا مجدد تلاش بفرمایید");
            var slug = model.Slug.Slugify();
            productcategory.Edit(model.Name, model.Description, model.Picture, model.PictureAlt,
                model.PictureTitle, model.Keywords, model.MetaDescription, slug);
            productCategoryRepository.SaveChanges();
            return opration.Sucsseded();
        }

        public EditProductCategory GetDetails(long Id)
        {
            return productCategoryRepository.GetDetails(Id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel search)
        {
            return productCategoryRepository.Search(search);
        }
    }
}
