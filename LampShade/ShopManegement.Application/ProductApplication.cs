using _0_Framework.Application;
using _0_Framwork.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
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

        public ProductApplication(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public OprationResult Create(CreateProduct Command)
        {
            var opration=new OprationResult();
            if (productRepository.Exists(s => s.Name == Command.Name))
                return opration.Feiled(ApplicationMessages.DublicatedRecord);
            var product = new Product(Command.Name, Command.Code, Command.UnitPrice,
                Command.Description, Command.ShortDescription, Command.Picture, 
                Command.PictureAlt, Command.PictureTitle, Command.Slug, Command.Keywords,
                Command.MetaDescription, Command.CategoryId);
            productRepository.Create(product);
            productRepository.SaveChanges();
            return opration.Sucsseded();
        }

        public OprationResult Edit(EditProduct Command)
        {
            var opration = new OprationResult();
            var result=productRepository.Get(Command.Id);
            if (result == null)
                return opration.Feiled(ApplicationMessages.RecordNotFound);
            if (productRepository.Exists(s => s.Name == Command.Name&&s.Id!=Command.Id))
                return opration.Feiled(ApplicationMessages.DublicatedRecord);
            var slugy = Command.Slug.Slugify();
            result.Edit(Command.Name, Command.Code, Command.UnitPrice,
                Command.Description, Command.ShortDescription, Command.Picture,
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

        public OprationResult InStock(long Id)
        {
            var opration = new OprationResult();
            var result = productRepository.Get(Id);
            if (result == null)
                return opration.Feiled(ApplicationMessages.RecordNotFound);
            result.InStock();
            productRepository.SaveChanges();
            return opration.Sucsseded();
        }

        public OprationResult NotInStock(long Id)
        {
            var opration = new OprationResult();
            var result = productRepository.Get(Id);
            if (result == null)
                return opration.Feiled(ApplicationMessages.RecordNotFound);
            result.NotInStock();
            productRepository.SaveChanges();
            return opration.Sucsseded();
        }

        public List<ProductViewModel> Search(ProductSearchModel Model)
        {
            return productRepository.Search(Model);
        }
    }
}
