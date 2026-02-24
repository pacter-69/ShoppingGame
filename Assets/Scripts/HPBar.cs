using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HPBar : MonoBehaviour, IConsume
{
    private Slider label;

    private void Awake()
    {
        label = GetComponent<Slider>();
    }

    private void OnDisable()
    {
       HPControl.OnHPChange -= UpdateSlider;
    }

    private void OnEnable()
    {
        HPControl.OnHPChange += UpdateSlider;
    }

    public void Consume(int value)
    {
        // Trucar a algun métode per updatejar la vida, potser s'hauria de canviar a HP Control
    }

    private void UpdateSlider(int HP)
    {
        label.value = HP;
    }
}