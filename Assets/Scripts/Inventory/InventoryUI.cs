using UnityEngine;
using System.Collections.Generic;

public class InventoryUI : MenuParent
{
    [SerializeField] private InventoryItemUI _UIPrefab;
    [SerializeField] private InventoryInfoUI _UIinfo;
    [SerializeField] private Transform _content;
    [SerializeField] private List<Item> _allItemsToLoad = new();

    private List<InventoryItemUI> _createdUI = new();

    public delegate void DelegateInventory(TypeMenu type);
    public static DelegateInventory OnOpenInventory;

    private void OnEnable()
    {
        if (Application.isEditor) return;
        InputManager.OnOpenInventory += Open;
        InputManager.OnInventoryExit += Close;
    }

    private void OnDisable()
    {
        if (Application.isEditor) return;
        InputManager.OnOpenInventory -= Open;
        InputManager.OnInventoryExit -= Close;
    }

    private void Start()
    {
        _allItemsToLoad.ForEach(n =>
        {
            LoadInfo(n);
            _createdUI[^1].gameObject.SetActive(GameManager.instance.Inventory.CheckItem(n, 1));

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
        _createdUI.ForEach(x => x.gameObject.SetActive(GameManager.instance.Inventory.CheckItem(x.ItemRenference, 1)));

        GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.MENU);

        UIManager.instance.ChangeMenu(Type);

        _UIinfo.ResetInfo();

        base.Open();
    }
}