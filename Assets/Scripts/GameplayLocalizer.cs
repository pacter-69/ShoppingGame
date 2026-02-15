using System;
using System.Collections.Generic;
using UnityEngine;

public class GameplayLocalizer : MonoBehaviour
{
    public static GameplayLocalizer Instance;

    public TextAsset dataSheet;

    Dictionary<string, GameplayLocalizer> data;

    public static event Action<string> OnLanguageChange;

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
        OnLanguageChange?.Invoke("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
