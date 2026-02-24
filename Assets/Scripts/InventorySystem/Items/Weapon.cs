using UnityEngine;

public abstract class Weapon : ItemBase
{
    protected int damage;

    private int durability;

    public void AddToDurability(int value)
    {
        durability += value;
        if(durability < 0) durability = 0;
    }

    public abstract void SharpenWeapon();
}

