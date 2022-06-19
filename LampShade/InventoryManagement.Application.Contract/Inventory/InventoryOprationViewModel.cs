using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract.Inventory
{
    public class InventoryOprationViewModel
    {
        public long Id { get; set; }
        public bool Operation { get; set; }
        public long Count { get; set; }
        public long OperatorId { get; set; }
        public string Operator { get; set; }
        public string OprationDate { get; set; }
        public long CurrentCount { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }
    }
}
