using _0_Framwork.Application;
using System.Collections.Generic;

namespace BlogManagement.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        OprationResult Create(CreateArticle command);
        OprationResult Edit(EditArticle command);
        EditArticle GetDetails(long Id);
        List<ArticleViewModel> Search(ArticleSearchModel model);
    }
}
