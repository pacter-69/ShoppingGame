using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class ScoreText : MonoBehaviour
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

    private void UpdateSlider(int HP)
    {
        label.value.CompareTo(HP) ;
        while (label.value.CompareTo(HP) == 1) { 
            label.value = label.value--;
            }
        while (label.value.CompareTo(HP) == -1)
            label.value = label.value++;
    }
}