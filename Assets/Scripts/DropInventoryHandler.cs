using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropInventoryHandler : MonoBehaviour, IDropHandler
{
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if ((eventData.pointerDrag) && (eventData.pointerDrag.GetComponent<ItemSlotUI>().GetInventoryUI() != gameObject.GetComponent<InventoryUI>()))
        {
            eventData.pointerDrag.GetComponent<ItemSlotUI>().GetInventoryUI().SellItemToOtherInventory(gameObject.GetComponent<InventoryUI>(), eventData.pointerDrag);
        }
    }
}
