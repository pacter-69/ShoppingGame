using UnityEngine;

public abstract class ConsumableItem : ItemBase
{
    public int healingPoints;
    public string healingPointsTextKey = "CONSUMABLE_HP";

    public abstract void Use(IConsume consumer);
}
