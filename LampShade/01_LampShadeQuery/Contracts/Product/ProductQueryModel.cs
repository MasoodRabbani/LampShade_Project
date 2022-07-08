using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Contracts.Product
{
    public class ProductQueryModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string PriceWithDiscount { get; set; }
        public int DiscountRate { get; set; }
        public string Category { get; set; }
        public string Sluge { get; set; }
        public bool HasDiscount { get; set; }
        public string DiscountExpireDate { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string CategorySlug { get; set; }
        public string Code { get; set; }
        public bool IsInStack { get; set; }
        public string KeyWords { get; set; }
        public List<CommentQueryModel> Comments { get; set; }
        public List<ProductPictureQueryModel>  Pictures { get; set; }
    }
    public class CommentQueryModel
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public long Id { get; set; }
    }
    public class ProductPictureQueryModel
    {
        public long ProductId { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
    }
}
