using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "Inventory System/Items/Weapons/Sword")]
public class Sword : Weapon
{
    public override void Use()
    {
        Debug.Log("Consumable item consumed!!!");
    }
}
