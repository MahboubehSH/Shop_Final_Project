using System.Collections.Generic;
using ShopManagement.Domain.OrderAgg;

namespace ShopManagement.Domain.Services
{
    public interface IInventoryAcl1
    {
        bool ReduceFromInventory(List<OrderItem> items);
    }
}
