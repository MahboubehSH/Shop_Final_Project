﻿using System.Collections.Generic;

namespace _01_ShopFinalQuery.Contracts.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetDetails(string slug);
        List<ProductQueryModel> GetLatestArrivals();
        List<ProductQueryModel> Search(string value);

    }
}
 