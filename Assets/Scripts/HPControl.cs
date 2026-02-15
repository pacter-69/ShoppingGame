using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HPControl : MonoBehaviour
{
    int HP = 100;
    public static event Action<int> OnHPChange;

    void OnDamage()
    {
        HP--;
        OnHPChange?.Invoke(HP);
    }
}
