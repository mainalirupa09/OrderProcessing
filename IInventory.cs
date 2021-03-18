namespace OrderProcessing
{
    public interface IInventory
    {
        bool CheckInventory(string productId, int qty);
    }
}