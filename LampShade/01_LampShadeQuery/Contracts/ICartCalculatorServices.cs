using _0_Framwork.Application;
using DiscountManagement.Infrastracture.EfCore;
using InventoryManagement.Infrastructure.EfCore;
using ShopManagement.Application.Contracts.Order;
using ShopManegement.Infrastracture.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Contracts
{
    public interface ICartCalculatorServices
    {
        Cart ComputeCart(List<CartItems> items);
    }
    public class CartCalclatorServices : ICartCalculatorServices
    {
        private readonly IAuthHelper authHelper;
        private readonly DiscountContext discountContext;

        public CartCalclatorServices(IAuthHelper authHelper, DiscountContext discountContext)
        {
            this.authHelper = authHelper;
            this.discountContext = discountContext;
        }

        public Cart ComputeCart(List<CartItems> items)
        {
            var cart = new Cart();
            var discountColleague = discountContext.ColleagueDiscounts
                .Where(s => !s.IsRemoved)
                .Select(s => new { s.ProductId, s.DiscountRate }).ToList();
            var discountCustomer = discountContext.CustomerDiscounts
                .Where(s => s.StartDate < DateTime.Now && s.EndDate > DateTime.Now)
                .Select(s => new { s.ProductId, s.DiscountRate }).ToList();


            foreach (var i in items)
            {
                if (authHelper.CurrentAccountRoleId()==Roles.Collague)
                {
                    if (discountColleague.Any(s=>s.ProductId==i.Id))
                    {
                        var dis = discountColleague.FirstOrDefault(s => s.ProductId == i.Id).DiscountRate;
                        if (dis != null)
                            i.DiscountRate = dis;
                    }
                }
                else
                {
                    if (discountCustomer.Any(s => s.ProductId == i.Id))
                    {
                        var dis = discountCustomer.FirstOrDefault(s => s.ProductId == i.Id).DiscountRate;
                        if (dis != null)
                            i.DiscountRate = dis;
                    }
                }
                i.DiscountAmount = (i.DiscountRate * i.UnitPrice) / 100;
                i.ItemPayAmount = i.TotalUnitPrice - i.DiscountAmount;
                cart.Add(i);
            }
            return cart;
        }
    }
}
