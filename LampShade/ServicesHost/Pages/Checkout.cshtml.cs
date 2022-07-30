using _01_LampShadeQuery.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;
using System.Collections.Generic;

namespace ServicesHost.Pages
{
    public class CheckoutModel : PageModel
    {
        public Cart Carts;
        public const string CookiName = "cart-items";
        private readonly ICartCalculatorServices cartCalculatorServices;

        public CheckoutModel(ICartCalculatorServices cartCalculatorServices)
        {
            this.cartCalculatorServices = cartCalculatorServices;
        }

        public void OnGet()
        {
            var serialaizer = new JavaScriptSerializer();
            var value = Request.Cookies[CookiName];
            var cartitems= serialaizer.Deserialize<List<CartItems>>(value);
            foreach (var item in cartitems)
                item.Totalunitprice();       
            Carts=cartCalculatorServices.ComputeCart(cartitems);
        }
    }
}
