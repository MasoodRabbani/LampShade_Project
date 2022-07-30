using System;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Order
{
    public class Cart
    {
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public List<CartItems> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItems>();
        }

        public void Add(CartItems i)
        {
            Items.Add(i);
            TotalAmount += i.TotalUnitPrice;
            DiscountAmount += i.DiscountAmount;
            PayAmount += i.ItemPayAmount;
            
        }
    }
}
