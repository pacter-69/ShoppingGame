using UnityEngine;

[CreateAssetMenu(fileName = "ItemBase", menuName = "Inventory System/Items/Generic item")]
public class ItemBase : ScriptableObject
{
    public string Name;
    public string description;
    public Sprite ImageUI;
    public bool IsStackable;
    public int cost;
    public string nameTextKey;
    public string descriptionTextKey;
    public string costTextKey = "ITEM_COST";
}
