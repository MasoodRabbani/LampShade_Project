using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegement.Infrastracture.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext context;
        public SlideRepository(ShopContext db) : base(db)
        {
            context = db;
        }

        public EditSlide GetDetails(long id)
        {
            return context.Slides.Select(s => new EditSlide
            {
                Id = id,
                BtnText = s.BtnText,
                Heading = s.Heading,
                Picture = s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                Text = s.Text,
                Title = s.Title,
                Link=s.Link,
            }).FirstOrDefault(s=>s.Id==id);
        }

        public List<SlideViewModel> GetList()
        {
            return context.Slides.Select(s=>new SlideViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Heading = s.Heading,
                Picture=s.Picture,
                IsRemove=s.IsRemove,
                CreationDate=s.CreationDate.ToFarsi()
            }).OrderByDescending(s=>s.Id).ToList();
        }
    }
}
