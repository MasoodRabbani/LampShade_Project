using _0_Framwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OprationResult Create(CreateProduct Command);
        OprationResult Edit(EditProduct Command);
        EditProduct GetDetails(long Id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel Model);
    }
}
