using UnityEngine;

[CreateAssetMenu(fileName = "Bread", menuName = "Inventory System/Items/Foods/Bread")]
public class ItemBread : ConsumableItem
{
    int healingPoints;

    public override void Use(IConsume consumer)
    {
        Debug.Log("Consumable item consumed!!!");
    }
}
