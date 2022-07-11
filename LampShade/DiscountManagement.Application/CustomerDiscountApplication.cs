using _0_Framwork.Application;
using Discount.Management.Domain.CoustomDiscountAgg;
using DiscountManagement.Application.Contract.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDicountRepository customerDicountRepository;

        public CustomerDiscountApplication(ICustomerDicountRepository customerDicountRepository)
        {
            this.customerDicountRepository = customerDicountRepository;
        }

        public OprationResult Define(DefineCustomerDiscount command)
        {
            var oprationresult = new OprationResult();
            if (customerDicountRepository.Exists(s=>s.ProductId==command.ProductId&&s.DiscountRate==command.DiscountRate))
            {
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            }
            var result = new CustomerDiscount(command.ProductId, command.DiscountRate, command
                .StartDate.ToGeorgianDateTime(), command.EndDate.ToGeorgianDateTime(), command.Reason);
            customerDicountRepository.Create(result);
            customerDicountRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public OprationResult Edit(EditCustomerDiscount command)
        {
            var oprationresult = new OprationResult();
            var customerdiscunt=customerDicountRepository.Get(command.Id);
            if (customerdiscunt==null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            if (customerDicountRepository.Exists(s => s.ProductId == command.ProductId && s.DiscountRate == command.DiscountRate&&s.Id!=command.Id))
            {
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            }
            customerdiscunt.Edit(command.ProductId, command.DiscountRate, command
                .StartDate.ToGeorgianDateTime(), command.EndDate.ToGeorgianDateTime(), command.Reason);
            customerDicountRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public EditCustomerDiscount GetDetails(long Id)
        {
            return customerDicountRepository.GetDetails(Id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel model)
        {
            return customerDicountRepository.Search(model);
        }
    }
}
