using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;

public class InventoryUI : MenuParent
{
    [SerializeField] private InventoryItemUI _UIPrefab;
    [SerializeField] private InventoryInfoUI _UIinfo;
    [SerializeField] private Transform _content;
    [SerializeField] internal List<Item> _allItemsToLoad = new();

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
        if (GameManager.instance.GameStatus.Status != EnumsData.GameFlow.GAMEPLAY) return;

        _createdUI.ForEach(x => x.gameObject.SetActive(GameManager.instance.Inventory.CheckItem(x.ItemRenference, 1)));

        GameManager.instance.GameStatus.UpdateFlow(EnumsData.GameFlow.MENU);

        UIManager.instance.ChangeMenu(Type);

        _UIinfo.ResetInfo();

        base.Open();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(InventoryUI))]
public class InventoryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        InventoryUI myTarget = (InventoryUI)target;

        base.OnInspectorGUI();

        GUILayout.Space(20);

        if (GUILayout.Button("Update Inventory SO"))
        {
            myTarget._allItemsToLoad.Clear();

            Item[] it = Resources.LoadAll<Item>("Items");
            //string[] prefabPaths = AssetDatabase.GetAllAssetPaths().Where(path => path.EndsWith(".asset", System.StringComparison.OrdinalIgnoreCase)).ToArray();
            Debug.Log(it.Length);

            myTarget._allItemsToLoad = it.ToList(); 
        }
    }  
}


#endif