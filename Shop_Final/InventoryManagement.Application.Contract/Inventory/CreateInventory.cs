namespace InventoryManagement.Application.Contract.Inventory
{
    public class CreateInventory
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
    }
}
