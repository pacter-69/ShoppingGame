using UnityEngine;
using UnityEngine.UIElements;

public class UseButtonBehaviour : MonoBehaviour, IMouseCaptureEvent
{
    public InventoryUI playerInventory;

    private void OnMouseDown()
    {
        UseItem();
    }

    public void UseItem()
    {
        playerInventory.UseSelectedItem();
    }
}
