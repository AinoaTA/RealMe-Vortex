using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MenuParent
{
    [SerializeField] private InventoryItemUI _UIPrefab;
    [SerializeField] private Transform _content;
    [SerializeField] private List<Item> _allItemsToLoad = new();

    private List<InventoryItemUI> _createdUI = new();

    public delegate void DelegateInventory(TypeMenu type);
    public static DelegateInventory OnOpenInventory;

    private void OnEnable()
    {
        InputManager.OnOpenInventory += Open;
        InputManager.OnInventoryExit += Close;
    }

    private void OnDisable()
    {
        InputManager.OnOpenInventory -= Open;
        InputManager.OnInventoryExit -= Close;
    }

    private void Start()
    {
        _allItemsToLoad.ForEach(n =>
        {
            LoadInfo(n);
            _createdUI[^1].gameObject.SetActive(Main.instance.Inventory.CheckItem(n, 1));

        });
    }

    private void LoadInfo(Item itemToLoad)
    {
        InventoryItemUI ui = Instantiate(_UIPrefab, transform.position, Quaternion.identity, _content);
        ui.Load(itemToLoad);
        _createdUI.Add(ui);
    }

    protected override void Open()
    {
        _createdUI.ForEach(x => x.gameObject.SetActive(Main.instance.Inventory.CheckItem(x.ItemRenference, 1)));

        Main.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.MENU);

        UIManager.instance.ChangeMenu(Type);
         
        base.Open();
    }
}