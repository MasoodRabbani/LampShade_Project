using _0_Framwork.Application;
using System.Collections.Generic;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OprationResult Define(DefineColleagueDiscount command);
        OprationResult Edit(EditColleagueDiscount command);
        OprationResult Remove(long Id);
        OprationResult Restore(long Id);
        EditColleagueDiscount GetDetails(long Id);
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel model);
    }
}
