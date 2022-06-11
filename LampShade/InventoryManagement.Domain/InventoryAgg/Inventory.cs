using _0_Framwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory:EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsStock { get; private set; }
        public List<InventoryOperation> InventoryOperations { get; private set; }

        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            IsStock = false;
        }
        private long CalculateInventoryStock()
        {
            var plus=InventoryOperations.Where(x=>x.Operation).Sum(x=>x.Count);
            var minus=InventoryOperations.Where(x=>!x.Operation).Sum(x=>x.Count);
            return plus-minus;
        }
        public void Increase(long count,long operatorid,string description)
        {
            var currentcount=CalculateInventoryStock()+count;
            var operation = new InventoryOperation(true, count, operatorid, currentcount, description, 0, Id);
            this.InventoryOperations.Add(operation);
            IsStock=currentcount>0;
        }
        public void Reduce(long count, long operatorid, string description,long orderid)
        {
            var currentcount=CalculateInventoryStock()-count;
            var opration=new InventoryOperation(false, count, operatorid, currentcount, description, orderid, Id);
            InventoryOperations.Add(opration);
            this.IsStock=currentcount>0;
        }
    }
    public class InventoryOperation
    {
        public long Id { get; private set; }
        public bool Operation { get; private set; }
        public long Count { get; private set; }
        public long OperationId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string Description { get; private set; }
        public long OrderId { get; private set; }
        public long InventoryId { get; private set; }
        public Inventory Inventory { get; set; }

        public InventoryOperation(bool operation, long count, long operationId,
            long currentCount, string description, long orderId, long inventoryId)
        {
            Operation = operation;
            Count = count;
            OperationId = operationId;
            CurrentCount = currentCount;
            Description = description;
            OrderId = orderId;
            InventoryId = inventoryId;
        }
    }
}
