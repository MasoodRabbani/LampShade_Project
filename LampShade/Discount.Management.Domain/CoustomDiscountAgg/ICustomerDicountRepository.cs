using _0_Framwork.Domain;
using DiscountManagement.Application.Contract.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Management.Domain.CoustomDiscountAgg
{
    public interface ICustomerDicountRepository:IRepository<long,CustomerDiscount>
    {
        EditCustomerDiscount GetDetails(long Id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel model);
    }
}
