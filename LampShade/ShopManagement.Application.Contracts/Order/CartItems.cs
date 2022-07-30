using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Order
{
    public class CartItems
    {
        public void Totalunitprice()
        {
            TotalUnitPrice = UnitPrice * Count;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public double UnitPrice { get; set; }
        public int Count { get; set; }
        public double TotalUnitPrice { get; set; }
        public bool IsInStack { get; set; }
        public int DiscountRate { get; set; }
        public double DiscountAmount { get; set; }
        public double ItemPayAmount { get; set; }
    }
}
