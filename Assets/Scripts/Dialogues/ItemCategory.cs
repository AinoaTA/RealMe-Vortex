using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "itemData", menuName = "SO/itemsData")]
public class ItemCategory : ScriptableObject
{
    public Items[] items;
    [System.Serializable]
    public struct Items
    {
        public EnumsData.Item itemType;
        public Item item;
    }

    public Items GetItem(EnumsData.Item reference) 
    {
        return items.ToList().Find(n => n.itemType == reference); 
    } 
}