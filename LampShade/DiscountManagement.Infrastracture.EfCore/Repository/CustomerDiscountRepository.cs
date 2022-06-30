using _0_Framwork.Infrastructure;
using _0_Framwork.Application;
using Discount.Management.Domain.CoustomDiscountAgg;
using DiscountManagement.Application.Contract.CustomerDiscount;
using ShopManegement.Infrastracture.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastracture.EfCore.Repository
{
    public class CustomerDiscountRepository :RepositoryBase<long,CustomerDiscount>, ICustomerDicountRepository
    {
        private readonly DiscountContext context;
        private readonly ShopContext shopcontext;
        public CustomerDiscountRepository(DiscountContext context, ShopContext shopcontext) :base(context)
        {
            this.context = context;
            this.shopcontext = shopcontext;
        }

        public EditCustomerDiscount GetDetails(long Id)
        {
            return context.CustomerDiscounts.Select(s => new EditCustomerDiscount
            {
                Id = s.Id,
                DiscountRate = s.DiscountRate,
                ProductId = s.ProductId,
                EndDate = s.EndDate.ToString(),
                Reason = s.Reason,
                StartDate = s.StartDate.ToString()
            }).FirstOrDefault(s => s.Id == Id);
        }
        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel model)
        {
            var product = shopcontext.Products.Select(s => new { Id = s.Id, Name = s.Name }).ToList();
            var query = context.CustomerDiscounts.Select(s => new CustomerDiscountViewModel
            {
                Id = s.Id,
                DiscountRate = s.DiscountRate,
                ProductId = s.ProductId,
                EndDate = s.EndDate.ToFarsi(),
                EndDateGr=s.EndDate,
                Reason = s.Reason,
                StartDate = s.StartDate.ToFarsi(),
                StartDateGr = s.StartDate,
                CreationDate=s.CreationDate.ToFarsi()
            });
            if (model.ProductId>0)
            {
                query = query.Where(s => s.ProductId == model.ProductId);
            }
            if (!string.IsNullOrWhiteSpace(model.StartDate))
            {
                query = query.Where(s => s.StartDateGr < model.StartDate.ToGeorgianDateTime());
            }
            if (!string.IsNullOrWhiteSpace(model.EndDate))
            {
                query = query.Where(s => s.EndDateGr > model.EndDate.ToGeorgianDateTime());
            }
            var discount = query.OrderByDescending(s => s.Id).ToList();
            discount.ForEach(x => x.Product = product.FirstOrDefault(s => s.Id == x.ProductId).Name);
            return discount;
        }
    }
}
