using UnityEngine;
using UnityEngine.UI;
 
public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Image _spriteRenderer;

    private Item _itemReference;

    public delegate void DelegateSendInfo(Item item);
    public static DelegateSendInfo OnSendInfo;
  
    public void Load(Item it)
    {
        _itemReference = it;
        _spriteRenderer.sprite = it.Sprite;
    }

    public void SendInfo()
    {
        if (_itemReference != null) //just in case.
            OnSendInfo?.Invoke(_itemReference);
    } 
}