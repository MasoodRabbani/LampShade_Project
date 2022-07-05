using _0_Framework.Application;
using _0_Framwork.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.Application
{
    public class ProductApplication:IProductApplication
    {
        private readonly IProductRepository productRepository;

        private readonly IFileUploader fileUploader;
        private readonly IProductCategoryRepository productCategory;

        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader, IProductCategoryRepository productCategory)
        {
            this.productRepository = productRepository;
            this.fileUploader = fileUploader;
            this.productCategory = productCategory;
        }

        public OprationResult Create(CreateProduct Command)
        {
            var opration=new OprationResult();
            if (productRepository.Exists(s => s.Name == Command.Name))
                return opration.Feiled(ApplicationMessages.DublicatedRecord);
            var slugy = Command.Slug.Slugify();
            var categorysluge=productCategory.GetSlugBy(Command.CategoryId);
            var path = $"{slugy}/{slugy}";
            var filename = fileUploader.Upload(Command.Picture, path);
            var product = new Product(Command.Name, Command.Code,
                Command.Description, Command.ShortDescription, filename, 
                Command.PictureAlt, Command.PictureTitle, slugy, Command.Keywords,
                Command.MetaDescription, Command.CategoryId);
            productRepository.Create(product);
            productRepository.SaveChanges();
            return opration.Sucsseded();
        }

        public OprationResult Edit(EditProduct Command)
        {
            var opration = new OprationResult();
            var result=productRepository.GetProductWithCategory(Command.Id);
            if (result == null)
                return opration.Feiled(ApplicationMessages.RecordNotFound);
            if (productRepository.Exists(s => s.Name == Command.Name&&s.Id!=Command.Id))
                return opration.Feiled(ApplicationMessages.DublicatedRecord);
            var slugy = Command.Slug.Slugify();
            var categorysluge = result.ProductCategory.Slug;
            var path = $"/{categorysluge}/{result.Slug}";
            var filename = fileUploader.Upload(Command.Picture, path);
            result.Edit(Command.Name, Command.Code, 
                Command.Description, Command.ShortDescription, filename,
                Command.PictureAlt, Command.PictureTitle, slugy, Command.Keywords,
                Command.MetaDescription, Command.CategoryId);
            productRepository.SaveChanges();
            return opration.Sucsseded();
        }

        public EditProduct GetDetails(long Id)
        {
            return productRepository.GetDetails(Id);
        }

        public List<ProductViewModel> GetProducts()
        {
           return productRepository.GetProducts();
        }

        public List<ProductViewModel> Search(ProductSearchModel Model)
        {
            return productRepository.Search(Model);
        }
    }
}
