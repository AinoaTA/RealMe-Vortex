using UnityEngine; 
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryItemUI _UIPrefab;
    [SerializeField] private Transform _content;

    private List<InventoryItemUI> _createdUI = new();

    private void Start()
    {
        Main.instance.Inventory.Items.ForEach(n => LoadInfo(n.item));
    }

    public void LoadInfo(Item itemToLoad)
    { 
        InventoryItemUI ui = Instantiate(_UIPrefab, transform.position, Quaternion.identity, _content);
        ui.Load(itemToLoad);
    }

    public void OnInventory()
    {

    }
}