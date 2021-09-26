using System.Collections.Generic;
using _01_ShopFinalQuery.Contracts.ArticleCategory;
using _01_ShopFinalQuery.Contracts.ProductCategory;

namespace _01_ShopFinalQuery
{
    public class MenuModel
    {
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        public List<ProductCategoryQueryModel> ProductCategories { get; set; }
    }
}
