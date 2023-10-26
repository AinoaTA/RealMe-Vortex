[System.Serializable]
public class InventoryData
{
    public Item Item { get => _item; private set => _item = value; }
    public Item _item;

    public int Quantity { get => _quantity; private set => _quantity = value; }
    public int _quantity;

    public InventoryData(Item item, int quantity)
    {
        this.Item = item;
        this.Quantity = quantity;
    }

    public bool CheckQuantity(float checkQuantity)
    {
        return Quantity >= checkQuantity;
    }

    public void AddQuantity(int quantity)
    {
        this.Quantity += quantity;
    }

    public void RemoveQuantity(int quantity)
    {
        this.Quantity -= quantity;
    }
}