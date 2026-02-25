using UnityEngine;

public abstract class ConsumableItem : ItemBase
{
    public int healingPoints;
    public abstract void Use(IConsume consumer);
}
