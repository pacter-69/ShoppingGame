using UnityEngine;
using TMPro;

public class LocalizeCLText : MonoBehaviour
{
    public string textKey;
    private TextMeshPro textValue;

    void Start()
    {
        textValue = GetComponent<TextMeshPro>();
        textValue.text = GameplayLocalizer.GetText(textKey);
    }

    private void OnEnable()
    {
        GameplayLocalizer.OnLanguageChange += ChangeLanguage;
    }

    private void OnDisable()
    {
        GameplayLocalizer.OnLanguageChange -= ChangeLanguage;
    }

    private void ChangeLanguage()
    {
        textValue.text = GameplayLocalizer.GetText(textKey);
    }
}
