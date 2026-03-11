using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeTextProNameAndCost : MonoBehaviour
{
    public InventoryUI playerInventory;
    private TextMeshPro textValue;

    private string nameKey, costKey;

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
            nameKey = selectedItem.nameTextKey;
            costKey = selectedItem.costTextKey;

            textValue.text = GameplayLocalizer.GetText(nameKey) + $": {selectedItem.cost} " + GameplayLocalizer.GetText(costKey);
        }
    }
}

