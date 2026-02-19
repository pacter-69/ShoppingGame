using UnityEngine;

public abstract class Weapon : ItemBase
{
    public int damage;

    public int durability;

    public abstract void Use();
}

