using _01_LampShadeQuery.Contracts.Slide;
using ShopManegement.Infrastracture.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext context;

        public SlideQuery(ShopContext context)
        {
            this.context = context;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return context.Slides.Where(s=>s.IsRemove==false)
                .Select(s => new SlideQueryModel
            {
                BtnText = s.BtnText,
                Heading = s.Heading,
                Picture = s.Picture,
                PictureAlt = s.PictureAlt,
                PictureTitle = s.PictureTitle,
                Text = s.Text,
                Title = s.Title,
                Link = s.Link,
            }).ToList();
        }
    }
}
