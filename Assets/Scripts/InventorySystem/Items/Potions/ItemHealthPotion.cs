using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotion", menuName = "Inventory System/Items/Foods/HealthPotion")]
public class ItemHealthPotion : ConsumableItem
{
    public override void Use(IConsume consumer)
    {
        Debug.Log("Consumable item consumed!!!");
    }
}
