using _0_Framwork.Application;
using Discount.Management.Domain.ColleagueDiscountAgg;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository colleagueDiscountRepository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
        {
            this.colleagueDiscountRepository = colleagueDiscountRepository;
        }

        public OprationResult Define(DefineColleagueDiscount command)
        {
            var oprationresult = new OprationResult();
            if (colleagueDiscountRepository.Exists(s=>s.ProductId==command.ProductId&&s.DiscountRate==command.DiscountRate))
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            var colleaguediscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
            colleagueDiscountRepository.Create(colleaguediscount);
            colleagueDiscountRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public OprationResult Edit(EditColleagueDiscount command)
        {
            var oprationresult = new OprationResult();
            var colleague=colleagueDiscountRepository.GetCategoryBy(command.Id);
            if (colleague == null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            if (colleagueDiscountRepository.Exists(s => s.ProductId == command.ProductId && s.DiscountRate == command.DiscountRate&&s.Id!=command.Id))
                return oprationresult.Feiled(ApplicationMessages.DublicatedRecord);
            colleague.Edit(command.ProductId, command.DiscountRate);
            colleagueDiscountRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public EditColleagueDiscount GetDetails(long Id)
        {
            return colleagueDiscountRepository.GetDeatails(Id);
        }

        public OprationResult Remove(long Id)
        {
            var oprationresult = new OprationResult();
            var colleague = colleagueDiscountRepository.GetCategoryBy(Id);
            if (colleague == null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            colleague.Remove();
            colleagueDiscountRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public OprationResult Restore(long Id)
        {
            var oprationresult = new OprationResult();
            var colleague = colleagueDiscountRepository.GetCategoryBy(Id);
            if (colleague == null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            colleague.Restore();
            colleagueDiscountRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel model)
        {
            return colleagueDiscountRepository.Search(model);
        }
    }
}
