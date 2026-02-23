using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "Inventory System/Items/Weapons/Sword")]
public class Sword : Weapon
{
    public override void SharpenWeapon()
    {
        Debug.Log("Weapon sharpened!!!");
    }
}
