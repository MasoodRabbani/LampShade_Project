using _0_Framwork.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.Application
{
    public class ProductPictureApplication:IProductPictureApplication
    {
        private readonly IProductPictureRepository productPictureRepository;
        private readonly IFileUploader fileUploader;
        private readonly IProductRepository productRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IFileUploader fileUploader, IProductRepository productRepository)
        {
            this.productPictureRepository = productPictureRepository;
            this.fileUploader = fileUploader;
            this.productRepository = productRepository;
        }

        public OprationResult Create(CreateProductPiccture Command)
        {
            var oprationres=new OprationResult();
            var product = productRepository.GetProductWithCategory(Command.ProductId);
            var path = $"{product.ProductCategory.Slug}/{product.Slug}";
            var filename = fileUploader.Upload(Command.Picture,path);
            var result = new ProductPicture(Command.ProductId, filename, Command.PictureAlt, Command.PictureTitle);
            productPictureRepository.Create(result);
            productPictureRepository.SaveChanges();
            return oprationres.Sucsseded();
        }

        public OprationResult Edit(EditProductPicture Command)
        {
            var oprationres = new OprationResult();
            var productpicture = productPictureRepository.GetProductAndCategory(Command.Id);
            if (productpicture == null)
                return oprationres.Feiled(ApplicationMessages.RecordNotFound);
            var path = $"{productpicture.Product.ProductCategory.Slug}/{productpicture.Product.Slug}";
            var filename = fileUploader.Upload(Command.Picture, path);
            productpicture.Edit(Command.ProductId, filename, Command.PictureAlt, Command.PictureTitle);
            productPictureRepository.SaveChanges();
            return oprationres.Sucsseded();
        }

        public EditProductPicture GetDetails(long Id)
        {
            return productPictureRepository.GetDetails(Id);
        }

        public OprationResult Remove(long Id)
        {
            var oprationresult = new OprationResult();
            var result = productPictureRepository.Get(Id);
            if (result == null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            result.Remove();
            productPictureRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public OprationResult Restore(long Id)
        {
            var oprationresult = new OprationResult();
            var result = productPictureRepository.Get(Id);
            if (result == null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            result.Restore();
            productPictureRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel Model)
        {
            return productPictureRepository.Search(Model);
        }
    }
}
