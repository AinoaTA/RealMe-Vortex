using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public List<InventoryData> items = new();

    public void AddItem(Item item, int quantity = 1)
    {
        InventoryData id = items.Find((n) => n.item == item);

        if (id == null)
        {
            items.Add(new(item, quantity));
        }
        else
        {
            id.AddQuantity(quantity);
        }
    }

    public void RemoveItem(Item item, int quantity)
    {
        if (CheckItem(item, quantity)) 
        {
            items.Find((n) => n.item == item).RemoveQuantity(quantity);
        } 
    }

    /// <summary>
    /// Check if player has the item with required quantity
    /// </summary>
    /// <returns></returns>
    public bool CheckItem(Item item, int quantity)
    {
        InventoryData id = items.Find((n) => n.item == item);

        if (id != null)
        {
            return id.CheckQuantity(quantity);
        }

        return false;
    }
}

[System.Serializable]
public class InventoryData
{
    public Item item { get; private set; }
    public int quantity { get; private set; }

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
