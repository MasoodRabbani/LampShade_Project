using _0_Framwork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory:EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keywords { get;private set; }
        public string MetaDescription { get;private set; }
        public string Slug { get;private set; }
        public List<ProductAgg.Product> Products { get; set; }

        public ProductCategory()
        {
            Products = new List<ProductAgg.Product>();
        }
        public ProductCategory(string name, string description, string piture, string pitureAlt, string pitureTitle, string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Picture = piture;
            PictureAlt = pitureAlt;
            PictureTitle = pitureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }
        public void Edit(string name, string description, string piture, string pitureAlt, string pitureTitle, string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            if(Picture!=null)
                Picture = piture;
            PictureAlt = pitureAlt;
            PictureTitle = pitureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }
    }
}
