using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ItemSlotUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public UnityEngine.UI.Image image;
    public TextMeshProUGUI amountText;

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
        image.sprite = slot.Item.ImageUI;
        image.SetNativeSize();

        amountText.text = slot.Amount.ToString();
        amountText.enabled = (slot.Amount > 1);

        item = slot.Item;
        this.slot = slot;
        this.inventory = inventory;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!canvas) canvas = GetComponentInParent<Canvas>();

        parent = transform.parent;

        transform.SetParent(canvas.transform, true);
        transform.SetAsLastSibling();

        OnGrabbedItemSlot?.Invoke();

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition += new Vector3(eventData.delta.x, eventData.delta.y, 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parent.transform);

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
