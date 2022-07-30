using _0_Framwork.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;
using System.Collections.Generic;
using System.Linq;
using System;
using _01_LampShadeQuery.Contracts.Product;

namespace ServicesHost.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItems> ItemsCart;
        public const string CookiName = "cart-items";
        private readonly IProductQuery productQuery;

        public CartModel(IProductQuery productQuery)
        {
            ItemsCart = new List<CartItems>();
            this.productQuery = productQuery;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = HttpContext.Request.Cookies[CookiName];
            var cartItems = serializer.Deserialize<List<CartItems>>(value);
            cartItems.ForEach(context => context.TotalUnitPrice = context.UnitPrice * context.Count);

            ItemsCart = productQuery.CheackInventoryStatus(cartItems);
        }
        public IActionResult OnGetRemoveFromCart(long id)
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookiName];
            Response.Cookies.Delete(CookiName);
            var cartItems = serializer.Deserialize<List<CartItems>>(value);
            var itemToRemove = cartItems.FirstOrDefault(x => x.Id == id);
            cartItems.Remove(itemToRemove);
            var model = serializer.Serialize(cartItems);
            var option = new CookieOptions { Expires = DateTime.Now.AddDays(2) ,SameSite=SameSiteMode.None};
            Response.Cookies.Append(CookiName,model,option);
            return RedirectToPage("/Cart");
        }
        public IActionResult OnGetGoToCheckout()
        {
            var serializer = new JavaScriptSerializer();
            var value = HttpContext.Request.Cookies[CookiName];
            var cartItems = serializer.Deserialize<List<CartItems>>(value);
            cartItems.ForEach(context => context.TotalUnitPrice = context.UnitPrice * context.Count);

            ItemsCart = productQuery.CheackInventoryStatus(cartItems);
            return Redirect(ItemsCart.Any(s => !s.IsInStack) ? "/Cart" : "/Checkout"); 
        }
    }
 
}
