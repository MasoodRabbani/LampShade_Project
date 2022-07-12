using System.Collections.Generic;

namespace _01_LampShadeQuery.Contracts.Article
{
    public interface IArticleQuery
    {
        List<ArticleQueryModel> LetestArticle();
        ArticleQueryModel GetArticleQueryModelBy(string Slug);
    }
}
