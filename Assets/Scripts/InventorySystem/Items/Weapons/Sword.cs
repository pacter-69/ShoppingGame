using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "Inventory System/Items/Weapons/Sword")]
public class Sword : Weapon
{
    public override void SharpenWeapon()
    {
        damage += 10;
        AddToDurability(-5);
        Debug.Log("Weapon sharpened!!!");
    }
}
