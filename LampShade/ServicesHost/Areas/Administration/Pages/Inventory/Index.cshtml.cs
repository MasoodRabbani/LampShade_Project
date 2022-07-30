using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framwork.Infrastructure;
using DiscountManagement.Application.Contract.CustomerDiscount;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Infrasturcture.Configuration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ServicesHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        public InventorySearchModel SearchModel;
        public List<InventoryViewModel> modelview;


        public SelectList Product;

        private readonly IProductApplication productApplication;
        private readonly IInventoryApplication inventoryApplication;

        public IndexModel(IProductApplication productApplication, IInventoryApplication inventoryApplication)
        {
            this.productApplication = productApplication;
            this.inventoryApplication = inventoryApplication;
        }
        [NeedsPermission(InventoryPermission.ListInventory)]
        public void OnGet(InventorySearchModel searchModel)
        {
            Product = new SelectList(productApplication.GetProducts(), "Id", "Name");
            modelview = inventoryApplication.Search(searchModel);
        }
        [NeedsPermission(InventoryPermission.CreateInventory)]

        public IActionResult OnGetCreate()
        {
            var command = new CreateInventory()
            {
                Products = productApplication.GetProducts()
            };
            return Partial("./Create", command );
        }
        [NeedsPermission(InventoryPermission.CreateInventory)]

        public IActionResult OnPostCreate(CreateInventory command)
        {
            var result = inventoryApplication.Create(command);
            return new JsonResult(result);
        }
        [NeedsPermission(InventoryPermission.EditInventory)]

        public IActionResult OnGetEdit(long id)
        {
            var inventory = inventoryApplication.GetDetails(id);
            inventory.Products = productApplication.GetProducts();
            return Partial("Edit", inventory);
        }
        [NeedsPermission(InventoryPermission.EditInventory)]

        public IActionResult OnPostEdit(EditInventory Command)
        {
            var resuly = inventoryApplication.Edit(Command);
            return new JsonResult(resuly);
        }
        [NeedsPermission(InventoryPermission.IncreaseInventory)]

        public IActionResult OnGetIncrease(long Id)
        {
            var result = new IncreaseInventory()
            {
                InventoryId = Id
            };
            return Partial("Increase",result);
        }
        [NeedsPermission(InventoryPermission.IncreaseInventory)]

        public IActionResult OnPostIncrease(IncreaseInventory command)
        {
            var result=inventoryApplication.Increase(command);
            if (result.IsSucsseded)
            {
                return new JsonResult(result);
                
            }
            Message = "عملیات ناموفق";
            return RedirectToPage("/Index");
        }
        [NeedsPermission(InventoryPermission.ReduceInventory)]

        public IActionResult OnGetReduce(long Id)
        {
            var result = new RecreaseInventory()
            {
                InventoryId = Id
            };
            return Partial("Reduce", result);
        }
        [NeedsPermission(InventoryPermission.ReduceInventory)]

        public IActionResult OnPostReduce(RecreaseInventory command)
        {
            var result = inventoryApplication.Reduce(command);
            if (result.IsSucsseded)
            {
                return new JsonResult(result);

            }
            Message = "عملیات ناموفق";
            return RedirectToPage("/Index");
        }
        [NeedsPermission(InventoryPermission.OprationLogInventory)]

        public IActionResult OnGetLog(long Id)
        {
            var result=inventoryApplication.GetOprationLog(Id);
            return Partial("OprationLog",result);
        }
    }
}
