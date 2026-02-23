using UnityEngine;

[CreateAssetMenu(fileName = "Meat", menuName = "Inventory System/Items/Foods/Meat")]
public class ItemWildfireRoastedMeat : ConsumableItem
{
    int healingPoints;

    public override void Use(IConsume consumer)
    {
        Debug.Log("Consumable item consumed!!!");
    }
}
