using System.Collections.Generic;
using System.Linq;
using InventoryManagement.Application.Contract.Inventory;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.Services;

namespace ShopManagement.InventoryAcl
{
     public class InventoryAcl1 : IInventoryAcl1
     {
         private readonly IInventoryApplication _inventoryApplication;

         public InventoryAcl1(IInventoryApplication inventoryApplication)
         {
             _inventoryApplication = inventoryApplication;
         }

         public bool ReduceFromInventory(List<OrderItem> items)
         {
             var command = items.Select(orderItem => new ReduceInventory(orderItem.ProductId, orderItem.Count, "خرید مشتری", orderItem.OrderId)).ToList();

             return _inventoryApplication.Reduce(command).IsSuccedded;
         }
    }
}
