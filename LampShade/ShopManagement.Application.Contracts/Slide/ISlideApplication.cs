using _0_Framwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OprationResult Create(CreateSlide Command);
        OprationResult Edit(EditSlide Command);
        OprationResult Remove(long Id);
        OprationResult Restore(long Id);
        EditSlide GetDetails(long Id);
        List<SlideViewModel> GetList();
    }
}
