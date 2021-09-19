using Microsoft.AspNetCore.Mvc.RazorPages;
using _01_ShopFinalQuery.Contracts.Product;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product;
        private readonly IProductQuery _productQuery;

        public ProductModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public void OnGet(string id)
        {
            Product = _productQuery.GetDetails(id);
        }
    }
}

