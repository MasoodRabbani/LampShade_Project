using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using Discount.Management.Domain.ColleagueDiscountAgg;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using ShopManegement.Infrastracture.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastracture.EfCore.Repository
{
    public class ColleagueDiscountRepository : RepositoryBase<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext context;
        private readonly ShopContext context2;

        public ColleagueDiscountRepository(DiscountContext context, ShopContext context2) :base(context)
        {
            this.context = context;
            this.context2 = context2;
        }

        public EditColleagueDiscount GetDeatails(long Id)
        {
            return context.ColleagueDiscounts.Select(s => new EditColleagueDiscount
            {
                Id = s.Id,
                DiscountRate = s.DiscountRate,
                ProductId = s.ProductId,
            }).FirstOrDefault(s => s.Id == Id);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel model)
        {
            var product = context2.Products.Select(s => new { Id = s.Id, Name = s.Name }).ToList();
            var query = context.ColleagueDiscounts.Select(s => new ColleagueDiscountViewModel
            {
                Id = s.Id,
                ProductId = s.ProductId,
                DiscountRate = s.DiscountRate,
                CreationDate = s.CreationDate.ToFarsi(),
                IsRemoved=s.IsRemoved
            });
            if(model.ProductId>0)
                query=query.Where(s => s.ProductId == model.ProductId);
            var discount = query.OrderByDescending(s => s.Id).ToList();
            discount.ForEach(s => s.Product = product.FirstOrDefault(x => x.Id==s.ProductId).Name);
            return discount;
        }
    }
}
