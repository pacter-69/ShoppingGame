using UnityEngine;

public abstract class Weapon : ItemBase
{
    public int damage;
    public string damageTextKey = "WEAPON_DAMAGE";

    public int durability;
    public string durabilityTextKey = "WEAPON_DURABILITY";

    public void AddToDurability(int value)
    {
        durability += value;
        if(durability < 0) durability = 0;
    }

    public abstract void SharpenWeapon();
}

