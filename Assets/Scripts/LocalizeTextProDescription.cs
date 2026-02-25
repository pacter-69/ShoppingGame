using TMPro;
using UnityEngine;

public class LocalizeTextProDescription : MonoBehaviour
{
    public InventoryUI playerInventory;
    private TextMeshPro textValue;

    private string descriptionKey;

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
            descriptionKey = selectedItem.descriptionTextKey;

            textValue.text = GameplayLocalizer.GetText(descriptionKey);
        }
        else textValue.text = "";
    }
}
