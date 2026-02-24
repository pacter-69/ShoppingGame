using UnityEngine;

[CreateAssetMenu(fileName = "Bread", menuName = "Inventory System/Items/Foods/Bread")]
public class ItemBread : ConsumableItem
{
    public override void Use(IConsume consumer)
    {
        consumer.Consume(healingPoints);
        Debug.Log("Bread consumed!!!");
    }
}
