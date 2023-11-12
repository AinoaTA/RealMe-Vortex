using UnityEngine;

[CreateAssetMenu(fileName = "itemData", menuName = "SO/itemsData")]
public class ItemCategory : ScriptableObject
{
    public Item[] items; 

    public Item GetItem(int index)
    {
        return items[index];
    } 
}