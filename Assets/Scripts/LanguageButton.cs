using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour, IPointerClickHandler
{
    public Language Language;

    private Text localizedText;

    public void Start()
    {
        localizedText = gameObject.GetComponentInChildren<Text>();
        localizedText.text = Language.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Language += 1;
        if (Language > Language.Spanish) Language = Language.English;

        GameplayLocalizer.SetLanguage(Language);

        // Make sure button displays current language text
        localizedText.text = Language.ToString();
    }
}
