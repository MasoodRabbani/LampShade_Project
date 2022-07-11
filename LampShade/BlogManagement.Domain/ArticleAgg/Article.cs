using _0_Framwork.Domain;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article:EntityBase
    {
        public long CategoryId { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public DateTime PublishDate { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string CanonalAddress { get; private set; }
        public ArticleCategoryAgg.ArticleCategory ArticleCategory { get; set; }

        public Article(long categoryId, string title, string shortDescription,
            string description, string picture, string pictureAlt, 
            string pictureTitle, string slug, DateTime publishDate, 
            string keywords, string metaDescription, string canonalAddress)
        {
            CategoryId = categoryId;
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            PublishDate = publishDate;
            Keywords = keywords;
            MetaDescription = metaDescription;
            CanonalAddress = canonalAddress;
        }

        public void Edit(long categoryId, string title, string shortDescription,
            string description, string picture, string pictureAlt, string pictureTitle,
            string slug, DateTime publishdate, string keywords, string mrtaDescription, string canonalAddress)
        {
            CategoryId = categoryId;
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = mrtaDescription;
            CanonalAddress = canonalAddress;
            PublishDate = publishdate;
        }
    }
}
