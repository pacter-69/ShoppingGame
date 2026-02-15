using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalizeText : MonoBehaviour
{
    public string TextKey;
    private Text textValue;

    void Start()
    {
        textValue = GetComponent<Text>();
        //textValue.text = GameplayLocalizer.Instance.GetText(TextKey);
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
        //textValue.text = GameplayLocalizer.Instance.GetText(TextKey);
    }
}
