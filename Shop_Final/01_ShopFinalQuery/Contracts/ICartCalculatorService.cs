using System.Collections.Generic;
using ShopManagement.Application.Contracts.Order;

namespace _01_ShopFinalQuery.Contracts
{
    public interface ICartCalculatorService
    {
        Cart ComputeCart(List<CartItem> cartItems);
    }
}
