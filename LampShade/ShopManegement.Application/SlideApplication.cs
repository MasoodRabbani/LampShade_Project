using _0_Framwork.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.Application
{
    public class SlideApplication:ISlideApplication
    {
        private readonly ISlideRepository slideRepository;
        private readonly IFileUploader fileUploader;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            this.slideRepository = slideRepository;
            this.fileUploader = fileUploader;
        }

        public OprationResult Create(CreateSlide Command)
        {
            var oprationresult=new OprationResult();
            var fileuploader = fileUploader.Upload(Command.Picture, "Slides"); 

            var result = new Slide(fileuploader, Command.PictureAlt, Command.PictureTitle, Command.Heading
                , Command.Title, Command.Text, Command.BtnText,Command.Link);
            slideRepository.Create(result);
            slideRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public OprationResult Edit(EditSlide Command)
        {
            var oprationresult = new OprationResult();
            var result = slideRepository.Get(Command.Id);
            if (result == null)
                return oprationresult.Feiled(ApplicationMessages.RecordNotFound);
            var fileuploader = fileUploader.Upload(Command.Picture, "Slides");
            result.Edit(fileuploader, Command.PictureAlt, Command.PictureTitle, Command.Heading
                , Command.Title, Command.Text, Command.BtnText, Command.Link);
            slideRepository.SaveChanges();
            return oprationresult.Sucsseded();
        }

        public EditSlide GetDetails(long Id)
        {
            return slideRepository.GetDetails(Id);
        }

        public List<SlideViewModel> GetList()
        {
            return slideRepository.GetList();
        }

        public OprationResult Remove(long Id)
        {
            var oprationres = new OprationResult();
            var result=slideRepository.Get(Id);
            if(result == null)
                return oprationres.Feiled(ApplicationMessages.RecordNotFound);
            result.Remove();
            slideRepository.SaveChanges();
            return oprationres.Sucsseded();
        }

        public OprationResult Restore(long Id)
        {
            var oprationres = new OprationResult();
            var result = slideRepository.Get(Id);
            if (result == null)
                return oprationres.Feiled(ApplicationMessages.RecordNotFound);
            result.Restore();
            slideRepository.SaveChanges();
            return oprationres.Sucsseded();
        }
    }
}
