using System.Collections.Generic;

public class CheckerCondition
{
    public CheckerCondition()
    {

    } 

    /// <summary>
    /// Check if players has the required items in its inventory.
    /// </summary>
    /// <param name="conditionInventory"></param>
    /// <returns></returns>
    public bool CheckCondition(InventoryData[] conditionInventory)
    {
        for (int i = 0; i < conditionInventory.Length; i++)
        {
            if (!Main.instance.Inventory.CheckItem(conditionInventory[i].Item, 1)) return false;
        }

        return true;
    }
}