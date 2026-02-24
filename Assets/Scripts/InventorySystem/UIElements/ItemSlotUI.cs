using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ItemSlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // NOTE: Inventory UI slots support drag&drop,
    // implementing the Unity provided interfaces by events system

    public UnityEngine.UI.Image Image;
    public TextMeshProUGUI AmountText;

    private Canvas canvas;
    private Transform parent;
    private ItemBase item;
    private InventoryUI inventory;
    private ItemSlot slot;

    public GameObject selectedAlert;

    public static event Action<GameObject> OnClickedItemSlot;
    public static event Action OnGrabbedItemSlot;

    public void Initialize(ItemSlot slot, InventoryUI inventory)
    {
        Image.sprite = slot.Item.ImageUI;
        Image.SetNativeSize();

        AmountText.text = slot.Amount.ToString();
        AmountText.enabled = (slot.Amount > 1);

        item = slot.Item;
        this.slot = slot;
        this.inventory = inventory;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // We need canvas as new UI reference (lazy initialization)
        if (!canvas) canvas = GetComponentInParent<Canvas>();

        // Store previous reference position
        parent = transform.parent;

        // Change parent of our item to the canvas
        transform.SetParent(canvas.transform, true);

        // And set it as last child to be rendered on top of UI
        transform.SetAsLastSibling();

        // Unselect item from inventory
        OnGrabbedItemSlot?.Invoke();

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Moving object around screen using mouse delta
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Find scene objects colliding with mouse point on end dragging
        //RaycastHit2D hitData = Physics2D.GetRayIntersection(
        //    Camera.main.ScreenPointToRay(Input.mousePosition), Mathf.Infinity, 1 << 3);

        /*RaycastHit2D hitData = Physics2D.GetRayIntersection(
    Camera.main.ScreenPointToRay(Input.mousePosition),
    Mathf.Infinity);

        if (hitData)
        {
            Debug.Log("Drop over object: " + hitData.collider.gameObject.name);

            var consumer = hitData.collider.gameObject.GetComponent<IConsume>();
            var buyer = hitData.collider.gameObject;

            if ((consumer != null) && (item is ConsumableItem))
            {
                (item as ConsumableItem).Use(consumer);
                inventory.UseItem(item);
            }
            else if((buyer != null) && (buyer.GetComponent<IBuy>() != null) && (buyer.GetComponent<InventoryUI>() != inventory))
            {
                // Changing parent back to slot
                transform.SetParent(parent.transform);

                // And centering item position
                transform.localPosition = Vector3.zero;

                inventory.SellItemToOtherInventory(buyer.GetComponent<InventoryUI>(), gameObject);
            }
        }*/

        // Changing parent back to slot
        transform.SetParent(parent.transform);

        // And centering item position
        transform.localPosition = Vector3.zero;

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void OnMouseDown()
    {
        OnClickedItemSlot?.Invoke(gameObject);
        Debug.Log("Item slot clickado: " + item.Name);
    }

    public ItemBase GetItem()
    {
        return item;
    }

    public ItemSlot GetItemSlot()
    {
        return slot;
    }

    public InventoryUI GetInventoryUI()
    {
        return inventory;
    }
}
