using UnityEngine;
using UnityEngine.UI;
 
public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Image _spriteRenderer;

    public Item ItemRenference { get; private set; }

    public delegate void DelegateSendInfo(Item item);
    public static DelegateSendInfo OnSendInfo;
  
    public void Load(Item it)
    {
        ItemRenference = it;
        _spriteRenderer.sprite = it.Sprite;
    }

    public void OnInventory()
    { 
        if (ItemRenference != null) //just in case.
            OnSendInfo?.Invoke(ItemRenference);
    }
}