using System.Collections.Generic;
using _01_ShopFinalQuery.Contracts.Product;
using _01_ShopFinalQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategory;
        public List<ProductQueryModel> LatestProducts;
        public List<ProductCategoryQueryModel> ProductCategories;

        private readonly IProductQuery _articleQuery;
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery, IProductQuery productQuery)
        {
            _productCategoryQuery = productCategoryQuery;
            _articleQuery = productQuery;
        }

        public void OnGet(string id)
        {
            ProductCategory = _productCategoryQuery.GetProductCategoryWithProductsBy(id);
            LatestProducts = _articleQuery.GetLatestArrivals();
            ProductCategories = _productCategoryQuery.GetProductCategories();
        }
    }
}
