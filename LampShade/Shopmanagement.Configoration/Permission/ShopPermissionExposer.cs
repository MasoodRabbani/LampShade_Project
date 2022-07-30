using _0_Framwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopmanagement.Configoration.Permission
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Exposer()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "Product",new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermission.ListProduct,"ListProduct"),
                        new PermissionDto(ShopPermission.SearchProduct,"SearchProduct"),
                        new PermissionDto(ShopPermission.CreateProduct,"CreateProduct"),
                        new PermissionDto(ShopPermission.EditProduct,"EditProduct"),
                    }
                },
                {
                    "ProductCategory",new List<PermissionDto>
                    {
                        new PermissionDto(ShopPermission.ListCategoryProduct,"ListProdductCategory"),
                        new PermissionDto(ShopPermission.CreateCategoryProduct,"CreateProdductCategory"),
                        new PermissionDto(ShopPermission.SearchCategoryProduct,"SearchProdductCategory"),
                        new PermissionDto(ShopPermission.EditCategoryProduct,"EditProdductCategory"),

                    }
                }
            };
        }
    }
}
