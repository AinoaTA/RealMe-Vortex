using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SO/Items")]
public class Item : ScriptableObject
{
    public string ObjectName { get => _objectName; }
    [SerializeField] private string _objectName;

    public Sprite Sprite { get => _sprite; }
    [SerializeField] private Sprite _sprite;



    public string InfoText { get => _infoText;  }
    [TextArea]
    [SerializeField] private string _infoText;
}