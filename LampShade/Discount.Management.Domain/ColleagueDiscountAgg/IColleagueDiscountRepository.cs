using DiscountManagement.Application.Contract.ColleagueDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Management.Domain.ColleagueDiscountAgg
{
    public interface IColleagueDiscountRepository: _0_Framwork.Domain.IRepository<long,ColleagueDiscount>
    {
        EditColleagueDiscount GetDeatails(long Id);
        List<ColleagueDiscountViewModel> Search(ColleageDiscountSearchModel model);
    }
}
