using System;
using UnityEngine;

public class ItemApple : ConsumableItem
{
    public override void Use(IConsume consumer)
    {
        Debug.Log("Consumable item consumed!!!");
    }
}
