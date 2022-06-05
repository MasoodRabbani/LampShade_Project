using _0_Framwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public  interface IProductPictureApplication
    {
        OprationResult Create(CreateProductPiccture Command);
        OprationResult Edit(EditProductPicture Command);
        OprationResult Remove(long Id);
        OprationResult Restore(long Id);
        EditProductPicture GetDetails(long Id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel Model);
    }
}
