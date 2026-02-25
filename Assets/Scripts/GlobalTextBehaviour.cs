using System;
using TMPro;
using UnityEngine;

public class GlobalTextBehaviour : MonoBehaviour
{
    private string textKey;
    private TextMeshPro textValue;

    private void Start()
    {
        textValue = GetComponent<TextMeshPro>();
    }

    private void OnEnable()
    {
        InventoryUI.OnGlobalText += UpdateTextKey;
    }
    private void OnDisable()
    {
        InventoryUI.OnGlobalText -= UpdateTextKey;
    }

    public void UpdateTextKey(string key)
    {
        textKey = key;
    }

    private void Update()
    {
        if (textKey != null)
        {
            textValue.text = GameplayLocalizer.GetText(textKey);
        }
    }
}
