﻿using _0_Framwork.Infrastructure;
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
                        new PermissionDto(10,"ListProduct"),
                        new PermissionDto(11,"SearchProduct"),
                        new PermissionDto(12,"CreateProduct"),
                        new PermissionDto(13,"EditProduct"),
                    }
                },
                {
                    "ProductCategory",new List<PermissionDto>
                    {
                        new PermissionDto(20,"ListProdductCategory"),
                        new PermissionDto(21,"CreateProdductCategory"),
                        new PermissionDto(22,"SearchProdductCategory"),
                        new PermissionDto(23,"EditProdductCategory"),

                    }
                }
            };
        }
    }
}