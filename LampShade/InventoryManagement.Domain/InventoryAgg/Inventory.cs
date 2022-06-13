using _0_Framwork.Domain;
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
        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
        }
        public long CalculateInventoryStock()
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
}
