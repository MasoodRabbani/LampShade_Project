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
        private readonly IFileUploader fileUploader;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.fileUploader = fileUploader;
        }

        public OprationResult Create(CreateProductCategory model)
        {
            var operationres = new OprationResult();
            if (productCategoryRepository.Exists(s=>s.Name==model.Name))
                return operationres.Feiled(ApplicationMessages.DublicatedRecord);
            var slug = model.Slug.Slugify();
            var namefolder = slug;
            var fileuploader = fileUploader.Upload(model.Picture, namefolder);
            var productcategory = new ProductCategory(model.Name, model.Description, fileuploader, model.PictureAlt,
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
                return opration.Feiled(ApplicationMessages.RecordNotFound);
            if (productCategoryRepository.Exists(s => s.Name == model.Name && s.Id != model.Id))
                return opration.Feiled(ApplicationMessages.RecordNotFound);
            var slug = model.Slug.Slugify();
            var namefolder = slug;
            var fileuploader = fileUploader.Upload(model.Picture,namefolder);
            productcategory.Edit(model.Name, model.Description, fileuploader, model.PictureAlt,
                model.PictureTitle, model.Keywords, model.MetaDescription, slug);
            productCategoryRepository.SaveChanges();
            return opration.Sucsseded();
        }

        public EditProductCategory GetDetails(long Id)
        {
            return productCategoryRepository.GetDetails(Id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return productCategoryRepository.GetProductCategories();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel search)
        {
            return productCategoryRepository.Search(search);
        }
    }
}
