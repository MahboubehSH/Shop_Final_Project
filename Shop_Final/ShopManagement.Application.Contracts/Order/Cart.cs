using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Order
{
    public class Cart
    {
        public double TotalAmount { get; set; } // مبلغ کل
        public double DiscountAmount { get; set; } // مبلغ تخفیف
        public double PayAmount { get; set; } // مبلغ پرداخت
        public List<CartItem> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public void Add(CartItem cartItem)
        {
            Items.Add(cartItem) ;
            TotalAmount += cartItem.TotalItemPrice;
            DiscountAmount += cartItem.DiscountAmount;
            PayAmount += cartItem.ItemPayAmount;
        }
    }
}