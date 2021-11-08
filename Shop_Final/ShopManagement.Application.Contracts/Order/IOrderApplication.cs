namespace ShopManagement.Application.Contracts.Order
{
    public interface IOrderApplication
    {
        long PlaceOrder(Cart cart);
        void PaymentSucceeded(long orderId, long refId);
    }
}
