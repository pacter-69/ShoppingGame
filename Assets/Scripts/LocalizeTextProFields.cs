using TMPro;
using UnityEngine;

public class LocalizeTextProFields : MonoBehaviour
{
    public InventoryUI playerInventory;
    private TextMeshPro textValue;

    private ItemSlotUI selectedSlot;

    void Start()
    {
        textValue = GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        selectedSlot = playerInventory.GetSelectedItemSlotUI();

        if (selectedSlot)
        {
            ItemBase selectedItem = selectedSlot.GetItem();

            if (selectedItem is Weapon)
            {
                string durabilityKey = (selectedItem as Weapon).durabilityTextKey;
                string damageKey = (selectedItem as Weapon).damageTextKey;
                textValue.text = GameplayLocalizer.GetText(durabilityKey) + $": {(selectedItem as Weapon).GetDurability()}\n" + GameplayLocalizer.GetText(damageKey) + $": {(selectedItem as Weapon).damage}";
            }
            else if (selectedItem is ConsumableItem)
            {
                string healingPointsKey = (selectedItem as ConsumableItem).healingPointsTextKey;
                textValue.text = GameplayLocalizer.GetText(healingPointsKey) + $": {(selectedItem as ConsumableItem).healingPoints}";
            }
            else textValue.text = "";
        }
    }
}
