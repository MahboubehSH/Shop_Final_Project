using System.Collections.Generic;

namespace _01_ShopFinalQuery.Contracts.Article
{
    public interface IArticleQuery
    {
        ArticleQueryModel GetArticleDetails(string slug);
        List<ArticleQueryModel> LatestArticles();
    }
}
