using _0_Framwork.Application;
using ShopManagement.Application.Contracts.ProductPicture;
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

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            this.productPictureRepository = productPictureRepository;
        }

        public OprationResult Create(CreateProductPiccture Command)
        {
            var oprationres=new OprationResult();
            if (productPictureRepository.Exists(s => s.Picture == Command.Picture && s.ProductId == Command.ProductId))
                return oprationres.Feiled(ApplicationMessages.DublicatedRecord);
            var result = new ProductPicture(Command.ProductId, Command.Picture, Command.PictureAlt, Command.PictureTitle);
            productPictureRepository.Create(result);
            productPictureRepository.SaveChanges();
            return oprationres.Sucsseded();
        }

        public OprationResult Edit(EditProductPicture Command)
        {
            var oprationres = new OprationResult();
            var productpicture = productPictureRepository.Get(Command.Id);
            if (productpicture == null)
                return oprationres.Feiled(ApplicationMessages.RecordNotFound);
            if (productPictureRepository.Exists(s => s.Picture == Command.Picture && s.ProductId == Command.ProductId&&s.Id!=Command.Id))
                return oprationres.Feiled(ApplicationMessages.DublicatedRecord);
            productpicture.Edit(Command.ProductId, Command.Picture, Command.PictureAlt, Command.PictureTitle);
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
