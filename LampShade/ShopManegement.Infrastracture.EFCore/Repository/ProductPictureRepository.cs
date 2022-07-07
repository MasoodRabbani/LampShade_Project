using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.Infrastracture.EFCore.Repository
{
    public class ProductPictureRepository:RepositoryBase<long,ProductPicture>,IProductPictureRepository
    {
        private readonly ShopContext context;

        public ProductPictureRepository(ShopContext context):base(context)
        {
            this.context = context;
        }

        public EditProductPicture GetDetails(long Id)
        {
            return context.ProductPictures.Select(p => new EditProductPicture
            {
                Id = p.Id,
                PictureAlt = p.PictureAlt,
                ProductId = p.ProductId,
                PictureTitle = p.PictureTitle
            }).FirstOrDefault(s => s.Id == Id);
        }

        public ProductPicture GetProductAndCategory(long id)
        {
            return context.ProductPictures.Include(s=>s.Product)
                .ThenInclude(s=>s.ProductCategory)
                .FirstOrDefault(s => s.Id == id); 
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = context.ProductPictures.Include(s => s.Product).Select(s => new ProductPictureViewModel
            {
                Id = s.Id,
                CreationDate = s.CreationDate.ToFarsi(),
                
                Picture = s.Picture,
                ProductId = s.ProductId,
                Product=s.Product.Name,
                IsRemoved=s.IsRemove
            });
            if (searchModel.ProductId!=0)
                query = query.Where(s => s.ProductId == searchModel.ProductId);
            return query.OrderByDescending(s=>s.Id).ToList();
        }
    }
}
