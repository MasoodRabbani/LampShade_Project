using _0_Framwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        OprationResult Create(CreateInventory command);
        OprationResult Edit(EditInventory command);
        OprationResult Increase(IncreaseInventory command);
        OprationResult Reduce(List<RecreaseInventory> command);
        OprationResult Reduce(RecreaseInventory command);
        EditInventory GetDetails(long Id);
        List<InventoryViewModel> Search(InventorySearchModel model);
        List<InventoryOprationViewModel> GetOprationLog(long InventoryId);
    }
}
