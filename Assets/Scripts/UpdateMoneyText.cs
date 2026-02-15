using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class UpdateMoneyText : MonoBehaviour
{
    public int money;

    public void Start()
    {
        GetComponent<Text>().text = money.ToString();
    }

    public void UpdateMoney(int amount)
    {
        money += amount;
        money = Mathf.Clamp(money, 0, int.MaxValue);
        GetComponent<Text>().text = money.ToString();
    }
}
