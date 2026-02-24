using UnityEngine;
using UnityEngine.UIElements;

public class BuyButtonBehaviour : MonoBehaviour, IMouseCaptureEvent
{
    public InventoryUI playerInventory, shopInventory;

    private void OnMouseDown()
    {
        SellItemToInventory();
    }

    public void SellItemToInventory()
    {
        shopInventory.SellItemToOtherInventory(playerInventory);
    }
}
