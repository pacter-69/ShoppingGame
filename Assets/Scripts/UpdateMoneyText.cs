using TMPro;
using UnityEngine.UI;
using UnityEngine;

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
        GetComponent<Text>().text = money.ToString();
    }
}
