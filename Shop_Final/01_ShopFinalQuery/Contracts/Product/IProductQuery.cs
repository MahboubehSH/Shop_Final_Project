using System.Collections.Generic;

namespace _01_ShopFinalQuery.Contracts.Product
{
    public interface IProductQuery
    {
        List<ProductQueryModel> GetLatestArrivals();
        List<ProductQueryModel> Search(string value);

    }
}
 