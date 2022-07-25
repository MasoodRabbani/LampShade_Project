﻿using _0_Framwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrasturcture.Configuration.Permission
{
    public class InventoryPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Exposer()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "Inventory",new List<PermissionDto>
                    {
                        new PermissionDto(50,"ListInventory"),
                        new PermissionDto(51,"SearchInventory"),
                        new PermissionDto(52,"CreateInventory"),
                        new PermissionDto(53,"EditInventory"),
                    }
                },
             };
        }
    }
}