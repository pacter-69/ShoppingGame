using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeTextProNameAndCost : MonoBehaviour
{
    public InventoryUI playerInventory;
    private TextMeshPro textValue;

    private string nameKey;

    private ItemSlotUI selectedSlot;

    void Start()
    {
        //textValue = GetComponent<TextMeshPro>();
        //textValue.text = GameplayLocalizer.GetText(TextKey);
    }

    private void Update()
    {
        selectedSlot = playerInventory.GetSelectedItemSlotUI();

        if (selectedSlot)
        {
            ItemBase selectedItem = selectedSlot.GetItem();
            nameKey = selectedItem.nameTextKey;

            textValue.text = GameplayLocalizer.GetText(nameKey);
        }
    }
}

