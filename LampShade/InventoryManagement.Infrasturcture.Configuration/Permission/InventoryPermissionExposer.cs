using _0_Framwork.Infrastructure;
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
                        new PermissionDto(InventoryPermission.ListInventory,"ListInventory"),
                        new PermissionDto(InventoryPermission.SearchInventory,"SearchInventory"),
                        new PermissionDto(InventoryPermission.CreateInventory,"CreateInventory"),
                        new PermissionDto(InventoryPermission.EditInventory,"EditInventory"),
                        new PermissionDto(InventoryPermission.IncreaseInventory,"IncreaseInventory"),
                        new PermissionDto(InventoryPermission.ReduceInventory,"ReduceInventory"),
                        new PermissionDto(InventoryPermission.OprationLogInventory,"OprationLogInventory"),
                    }
                },
             };
        }
    }
}
