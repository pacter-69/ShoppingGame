using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Items/Apple")]
public class ItemApple : ConsumableItem
{
    public override void Use(IConsume consumer)
    {
        consumer.Consume(healingPoints);
        Debug.Log("Apple consumed!");
    }
}
