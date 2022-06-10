using _0_Framwork.Application;
using System.Collections.Generic;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OprationResult Define(DefineCustomerDiscount command);
        OprationResult Edit(EditCustomerDiscount command);
        EditCustomerDiscount GetDetails(long Id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel model);
    }
}
