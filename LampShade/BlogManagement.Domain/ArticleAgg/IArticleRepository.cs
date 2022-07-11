using _0_Framwork.Domain;
using BlogManagement.Application.Contracts.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository:IRepository<long, Article>
    {
        Article GetCategoryBy(long Id);
        EditArticle GetDetails(long id);
        List<ArticleViewModel> Search(ArticleSearchModel model);
    }
}
