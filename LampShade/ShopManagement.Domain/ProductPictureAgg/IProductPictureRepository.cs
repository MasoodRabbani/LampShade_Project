using _0_Framwork.Domain;
using ShopManagement.Application.Contracts.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository:IRepository<long,ProductPicture>
    {
        ProductPicture GetProductAndCategory(long id);
        EditProductPicture GetDetails(long Id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
