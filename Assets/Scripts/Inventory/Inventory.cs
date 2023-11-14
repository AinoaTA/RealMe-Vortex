using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<InventoryData> Items { get => _items; private set => _items = value; }

    //public delegate void DelegateInventoryDot(bool show);
    //public static DelegateInventoryDot OnInventoryAdded;

    [SerializeField] private List<InventoryData> _items = new();

    private void OnEnable()
    {
        GrabObject.OnGrab += AddItem;
    }

    private void OnDisable()
    {
        GrabObject.OnGrab -= AddItem;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddItem(Item item, int quantity = 1)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/GetItem");
        InventoryData id = Items.Find((n) => n.Item == item);

        if (id == null)
        {
            Items.Add(new(item, quantity));
        }
        else
        {
            id.AddQuantity(quantity);
        }
         
        InventoryDot.OnShow?.Invoke(true);
    }

    public void RemoveItem(Item item, int quantity)
    {
        if (CheckItem(item, quantity))
        {
            Items.Find((n) => n.Item == item).RemoveQuantity(quantity);
        }
    }


    /// <summary>
    /// Check if player has the item with required quantity
    /// </summary>
    /// <returns></returns>
    public bool CheckItem(Item item, int quantity)
    {
        InventoryData id = Items.Find((n) => n.Item == item);

        if (id != null)
        {
            return id.CheckQuantity(quantity);
        }

        return false;
    }
}