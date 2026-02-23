using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory Inventory;
    public ItemSlotUI SlotPrefab;
    public GameObject selectedSlot;

    List<GameObject> itemSlotList;

    public event Action<GameObject> OnUsedItem;

    void Start()
    {
        FillInventoryUI(Inventory);
    }

    private void OnEnable()
    {
        Inventory.OnInventoryChange += UpdateInventoryUI;

        ItemSlotUI.OnClickedItemSlot += SelectCurrentItem;
        ItemSlotUI.OnGrabbedItemSlot += UnselectCurrentItem;
    }

    private void OnDisable()
    {
        Inventory.OnInventoryChange -= UpdateInventoryUI;

        ItemSlotUI.OnClickedItemSlot -= SelectCurrentItem;
        ItemSlotUI.OnGrabbedItemSlot -= UnselectCurrentItem;
    }

    private void UpdateInventoryUI()
    {
        // Regenerate full inventory on changes
        ClearInventoryUI();
        FillInventoryUI(Inventory);
        UnselectCurrentItem();
    }

    private void ClearInventoryUI()
    {
        foreach (var item in itemSlotList)
        {
            if (item) Destroy(item);
        }

        itemSlotList.Clear();
    }

    private void FillInventoryUI(Inventory inventory)
    {
        // Lazy initialization for objects list
        if (itemSlotList == null) itemSlotList = new List<GameObject>();

        if (itemSlotList.Count > 0) ClearInventoryUI();

        for (int i = 0; i < inventory.Length; i++)
        {
            itemSlotList.Add(AddSlot(inventory.GetSlot(i)));
        }
    }

    private GameObject AddSlot(ItemSlot itemSlot)
    {
        // Add a new visual slot UI in inventory UI, using provided prefab
        var element = Instantiate(SlotPrefab, Vector3.zero, Quaternion.identity, transform);

        element.Initialize(itemSlot, this);

        return element.gameObject;
    }

    public void UseItem(ItemBase item)
    {
        if (HasSelectedItemInInventory())
        {
            OnUsedItem?.Invoke(selectedSlot);
            item.Use();
            UnselectCurrentItem();
            Inventory.RemoveItem(item);
        }
    }

    public void UseSelectedItem()
    {
        UseItem(selectedSlot.GetComponent<ItemSlotUI>().GetItem());
    }

    public void SelectCurrentItem(GameObject selectItem)
    {
        if (HasSelectedItemInInventory())
        // This is supposed to check if the item is in the current inventory, so that it could be possible to have one selected item per
        // inventory, but it currently doesn't work.
        {
            if (selectedSlot != null) UnselectCurrentItem();
            selectedSlot = selectItem;
            selectItem.GetComponent<ItemSlotUI>().selectedAlert.SetActive(true);
        }
    }

    public void UnselectCurrentItem()
    {
        if(selectedSlot)
        {
            selectedSlot.GetComponent<ItemSlotUI>().selectedAlert.SetActive(false);
            selectedSlot = null;
        }
    }

    public bool HasSelectedItemInInventory()
    {
        if (selectedSlot == null) return true;
        else return Inventory.HasItem(selectedSlot.GetComponent<ItemSlotUI>().GetItemSlot());
    }
}
