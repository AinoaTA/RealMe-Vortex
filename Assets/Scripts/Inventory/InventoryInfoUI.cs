using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventoryInfoUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _info;
    private string _empty = "";
    private void OnEnable()
    {
        InventoryItemUI.OnSendInfo += UpdateInfo;
    }

    private void OnDisable()
    {
        InventoryItemUI.OnSendInfo -= UpdateInfo;
    }

    private void Start()
    {
        ResetInfo();
    }

    private void UpdateInfo(Item item)
    {
        _image.color = new(1, 1, 1, 1);

        _image.sprite = item.Sprite;
        _name.text = item.ObjectName;
        _info.text = item.InfoText; 
    }

    public void ResetInfo()
    {
        _image.color = new(1, 1, 1, 0);
        _name.text = _empty;
        _info.text = _empty;
    } 
}