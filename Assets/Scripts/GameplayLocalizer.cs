using System;
using System.Collections.Generic;
using UnityEngine;

public class GameplayLocalizer : MonoBehaviour
{
    public static GameplayLocalizer Instance;

    public TextAsset dataSheet;

    private Language currentLanguage;
    public Language DefaultLanguage;

    Dictionary<string, LanguageData> Data; // Text data from CSV

    public static event Action OnLanguageChange;

    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
