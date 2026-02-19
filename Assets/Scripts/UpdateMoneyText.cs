using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdateMoneyText : MonoBehaviour
{
    public int money;

    public void Start()
    {
        GetComponent<Text>().text = money.ToString();
    }

    void OnDamage()
    {
        UpdateMoney(100);
    }

    public void UpdateMoney(int amount)
    {
        money += amount;
        money = Mathf.Clamp(money, 0, int.MaxValue);
        GetComponent<Text>().text = money.ToString();
    }
}
