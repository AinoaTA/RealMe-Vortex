[System.Serializable]
public class InventoryData
{
    public Item item { get => _item; private set => _item = value; }
    public Item _item;

    public int quantity { get => _quantity; private set => _quantity = value; }
    public int _quantity;

    public InventoryData(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }

    public bool CheckQuantity(float checkQuantity)
    {
        return quantity >= checkQuantity;
    }

    public void AddQuantity(int quantity)
    {
        this.quantity += quantity;
    }

    public void RemoveQuantity(int quantity)
    {
        this.quantity -= quantity;
    }
}