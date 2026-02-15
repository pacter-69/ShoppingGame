using UnityEngine;

[CreateAssetMenu(fileName = "ItemBase", menuName = "Inventory System/Items/Generic item")]
public class ItemBase : ScriptableObject
{
    public string Name;
    public Sprite ImageUI;
    public bool IsStackable;
    public int cost;
}
