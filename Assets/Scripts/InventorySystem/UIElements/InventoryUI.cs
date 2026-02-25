using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory Inventory;
    public ItemSlotUI SlotPrefab;
    public bool isPlayer;

    [SerializeField]
    private GameObject selectedSlot;

    public GameObject MoneyTextObject;

    public GameObject consumer;

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
        if (itemSlotList == null) itemSlotList = new List<GameObject>();

        if (itemSlotList.Count > 0) ClearInventoryUI();

        for (int i = 0; i < inventory.Length; i++)
        {
            itemSlotList.Add(AddSlot(inventory.GetSlot(i)));
        }
    }

    private GameObject AddSlot(ItemSlot itemSlot)
    {
        var element = Instantiate(SlotPrefab, Vector3.zero, Quaternion.identity, transform);

        element.Initialize(itemSlot, this);

        return element.gameObject;
    }

    public void UseItem(ItemBase item)
    {
        if (HasSelectedItemInInventory() && isPlayer)
        {
            if (item is ConsumableItem)
            {
                UnselectCurrentItem();
                (item as ConsumableItem).Use(consumer.GetComponent<IConsume>());
                Inventory.RemoveItem(item);
                OnUsedItem?.Invoke(selectedSlot);
            }
            else if (item is Weapon)
            {
                UnselectCurrentItem();
                (item as Weapon).SharpenWeapon();
                Debug.Log ((item as Weapon).GetDurability());
                if ((item as Weapon).GetDurability()<=0){
                    Inventory.RemoveItem(item);
                    
                    }
                OnUsedItem?.Invoke(selectedSlot);
            }
            else
            {
                Debug.Log("�Este item no es consumible!");
            }
        }
    }

    public void UseSelectedItem()
    {
        if (selectedSlot)
        {
            UseItem(selectedSlot.GetComponent<ItemSlotUI>().GetItem());
        }
    }

    private void SelectCurrentItem(GameObject selectItem)
    {
        if (selectedSlot != null) UnselectCurrentItem();
        selectedSlot = selectItem;
        selectItem.GetComponent<ItemSlotUI>().selectedAlert.SetActive(true);

    }

    private void UnselectCurrentItem()
    {
        if (selectedSlot)
        {
            selectedSlot.GetComponent<ItemSlotUI>().selectedAlert.SetActive(false);
            selectedSlot = null;
        }
    }

    private bool HasSelectedItemInInventory()
    {
        if (selectedSlot == null) return true;
        else return Inventory.HasItem(selectedSlot.GetComponent<ItemSlotUI>().GetItemSlot());
    }

    private void AddMoney(int value)
    {
        MoneyTextObject.GetComponent<UpdateMoneyText>().UpdateMoney(value);
    }

    public void SellItemToOtherInventory(InventoryUI otherInventory)
    {
        int itemCost = selectedSlot.GetComponent<ItemSlotUI>().GetItem().cost;

        if (otherInventory.CanBuyItem(itemCost) && selectedSlot.GetComponent<ItemSlotUI>().GetInventoryUI() == this)
        {
            ItemSlotUI selectedSlotUI = selectedSlot.GetComponent<ItemSlotUI>();

            Inventory.RemoveItem(selectedSlotUI.GetItem());
            otherInventory.Inventory.AddItem(selectedSlotUI.GetItem());

            AddMoney(itemCost);
            otherInventory.AddMoney(-itemCost);

            Debug.Log("�Transition made!");
        }
        else
        {
            Debug.Log("Some party doesn't have enough resources for this transaction...");
        }
    }

    public void SellItemToOtherInventory(InventoryUI otherInventory, GameObject itemToSell)
    {
        int itemCost = itemToSell.GetComponent<ItemSlotUI>().GetItem().cost;

        if (otherInventory.CanBuyItem(itemCost) && itemToSell.GetComponent<ItemSlotUI>().GetInventoryUI() == this)
        {
            ItemSlotUI itemToSellUI = itemToSell.GetComponent<ItemSlotUI>();

            Inventory.RemoveItem(itemToSellUI.GetItem());
            otherInventory.Inventory.AddItem(itemToSellUI.GetItem());

            AddMoney(itemCost);
            otherInventory.AddMoney(-itemCost);

            Debug.Log("�Transition made!");
        }
        else
        {
            Debug.Log("Some party doesn't have enough resources for this transaction...");
        }
    }

    private bool CanBuyItem(int itemValue)
    {
        return MoneyTextObject.GetComponent<UpdateMoneyText>().GetMoney() - itemValue >= 0;
    }

    public ItemSlotUI GetSelectedItemSlotUI()
    {
        if (selectedSlot) return selectedSlot.GetComponent<ItemSlotUI>();
        else return null;
    }
}
