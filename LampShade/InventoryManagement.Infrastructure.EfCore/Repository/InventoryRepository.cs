using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManegement.Infrastracture.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext context;
        private readonly ShopContext context2;
        public InventoryRepository(InventoryContext context, ShopContext context2) :base(context)
        {
            this.context = context;
            this.context2 = context2;   
        }
        public Inventory GetBy(long productId)
        {
            return context.Inventories.FirstOrDefault(s=>s.ProductId==productId);
        }

       public EditInventory GetDetails(long Id)
        {
            return context.Inventories.Select(s=>new EditInventory
            {
                Id=s.Id,
                ProductId=s.ProductId,
                UnitPrice=s.UnitPrice
            }).FirstOrDefault(s=>s.Id==Id);
        }

        public List<InventoryOprationViewModel> GetOprationLog(long InventoryId)
        {
            var inventory = context.Inventories.FirstOrDefault(s => s.Id == InventoryId);
            return inventory.InventoryOperations.Select(s=>new InventoryOprationViewModel
            {
                Id = s.Id,
                Count=s.Count,
                CurrentCount=s.CurrentCount,
                Description=s.Description,
                OprationDate=s.OperationDate.ToFarsi(),
                Operator="مدیر سیستم",
                Operation=s.Operation,
                OperatorId=s.OperatorId,
                OrderId=s.OrderId,
            }).OrderByDescending(s=>s.Id).ToList();
        }

        public List<InventoryViewModel> Search(InventorySearchModel model)
        {
            var product = context2.Products.Select(s=>new {Id=s.Id,Name=s.Name}).ToList();
            var query = context.Inventories.Select(s => new InventoryViewModel
            {
                Id = s.Id,
                UnitPrice = s.UnitPrice,
                IsStock = s.IsStock,
                ProductId = s.ProductId,
                CurrentCount=s.CalculateInventoryStock(),
                CreationDate=s.CreationDate.ToFarsi()
            });
            if(model.ProductId>0)
                query=query.Where(s=>s.ProductId==model.ProductId);
            if(model.IsStock)
                query=query.Where(s=>s.IsStock==model.IsStock);
            var inventory = query.OrderByDescending(s => s.Id).ToList();
            inventory.ForEach(s =>s.Product = product.FirstOrDefault(x => x.Id == s.ProductId)?.Name);
            return inventory;
        }
    }
}
