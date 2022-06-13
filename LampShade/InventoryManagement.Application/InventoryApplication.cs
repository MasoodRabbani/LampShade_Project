
using _0_Framwork.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository inventoryRepository;

        public InventoryApplication(IInventoryRepository repository)
        {
            inventoryRepository = repository;
        }

        public OprationResult Create(CreateInventory command)
        {
            var oprationresult = new OprationResult();
            if (inventoryRepository.Exists(s => s.ProductId == command.ProductId))
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            inventoryRepository.Create(inventory);
            inventoryRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public OprationResult Edit(EditInventory command)
        {
            var oprationresult = new OprationResult();
            var inventory=inventoryRepository.Get(command.Id);
            if (inventory == null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            if (inventoryRepository.Exists(s => s.ProductId == command.ProductId&&s.Id!=command.Id))
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            inventory.Edit(command.ProductId, command.UnitPrice);
            inventoryRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public EditInventory GetDetails(long Id)
        {
            return inventoryRepository.GetDetails(Id);
        }

        public OprationResult Increase(IncreaseInventory command)
        {
            var oprationresult = new OprationResult();
            var inventory = inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            const long operatorid = 1;
            inventory.Increase(command.Count, operatorid, command.Discription);
            inventoryRepository.SaveChanges();
            return oprationresult.Sucsseded();  
        }

        public OprationResult Reduce(List<RecreaseInventory> command)
        {
            var oprationresult = new OprationResult();
            foreach (var item in command)
            {
                var inventory = inventoryRepository.GetBy(item.ProductId);
                inventory.Reduce(item.Count, 1, item.Description,item.OrderId);
            }
            inventoryRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public OprationResult Reduce(RecreaseInventory command)
        {
            var oprationresult = new OprationResult();
            var inventory = inventoryRepository.Get(command.InventoryId);
            if (inventory == null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            const long operatorid = 1;
            inventory.Reduce(command.Count, operatorid, command.Description,0);
            inventoryRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public List<InventoryViewModel> Search(InventorySearchModel model)
        {
            return inventoryRepository.Search(model);
        }

    }
}
