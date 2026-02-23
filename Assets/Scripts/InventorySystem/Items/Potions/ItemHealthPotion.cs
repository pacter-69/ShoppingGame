using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotion", menuName = "Inventory System/Items/Potions/HealthPotion")]
public class ItemHealthPotion : ConsumableItem
{
    int healingPoints;

    public override void Use(IConsume consumer)
    {
        Debug.Log("Consumable item consumed!!!");
    }
}
