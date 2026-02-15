using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameplayLocalizer : MonoBehaviour
{
    public static GameplayLocalizer Instance;

    public TextAsset dataSheet;

    private Language currentLanguage;
    public Language defaultLanguage;

    Dictionary<string, LanguageData> data; // Text data from CSV

    public static event Action OnLanguageChange;

    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        LoadLanguageSheet();
    }
    public static string GetText(string textKey)
    {
        return Instance.data[textKey].GetText(Instance.currentLanguage);
    }

    public static void SetLanguage(Language language)
    {
        Instance.currentLanguage = language;

        OnLanguageChange?.Invoke();
    }

    void LoadLanguageSheet()
    {
        string[] lines = dataSheet.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines.Length > 1) AddLanguageData(lines[i]);
        }
    }

    void AddLanguageData(string str)
    {
        // Lazy initialization
        if (data == null) data = new Dictionary<string, LanguageData>();

        string[] entries = str.Split(';');

        var languageData = new LanguageData(entries);

        data.Add(entries[0], languageData);
    }
}
