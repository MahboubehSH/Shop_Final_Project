namespace ShopManagement.Application.Contracts.Order
{
    public class CartItem
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public double UnitPrice { get; set; }
            public string Picture { get; set; }
            public int Count { get; set; }
            public double TotalItemPrice { get; set; } // مبلغ کل یا قبل از تخفیف
            public bool IsInStock { get; set; }
            public int DiscountRate { get; set; } //درصد تخفیف
            public double DiscountAmount { get; set; }  //مبلغ تخفیف
            public double ItemPayAmount { get; set; } //مبلغ پس از کسر تخفیف

        public CartItem()
        {
            //TotalItemPrice = UnitPrice * Count;
        }

        public void CalculateTotalItemPrice()
            {
                TotalItemPrice = UnitPrice * Count;
            }
        }
    
}
