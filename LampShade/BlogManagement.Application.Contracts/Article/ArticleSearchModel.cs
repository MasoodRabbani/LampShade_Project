using BlogManagement.Application.Contracts.ArticleCategory;
using System.Collections.Generic;

namespace BlogManagement.Application.Contracts.Article
{
    public class ArticleSearchModel
    {
        public long CategoryId { get; set; }
        public string Title { get; set; }
        public List<ArticleCategoryViewModel> Categoris { get; set; }

    }
}
