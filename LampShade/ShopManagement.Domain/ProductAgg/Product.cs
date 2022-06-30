using _0_Framwork.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product:EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public string Description { get; private set; }
        public string ShortDescription { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public long CategoryId { get; private set; }
        public ProductCategoryAgg.ProductCategory ProductCategory { get; set; }
        public List<ProductPictureAgg.ProductPicture> ProductPictures { get; set; }

        public Product(string name, string code, 
            string description, string shortDescription, string picture, 
            string pictureAlt, string pictureTitle, string slug, string keywords, 
            string metaDescription, long categoryId)
        {
            Name = name;
            Code = code;
            Description = description;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }
        public void Edit(string name, string code,
            string description, string shortDescription, string picture,
            string pictureAlt, string pictureTitle, string slug, string keywords,
            string metaDescription, long categoryId)
        {
            Name = name;
            Code = code;
            Description = description;
            ShortDescription = shortDescription;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CategoryId = categoryId;
        }
    }
}
