using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HPControl : MonoBehaviour
{
    int HP = 100;
    public static event Action<int> OnHPChange;
    public static event Action OnDeath;
    public static bool alive = true;


    void OnDamage()
    {
        HP--;
        if (HP == 0)
        {
            Death();
        }
        OnHPChange?.Invoke(HP);
    }

    void Death()
    {
        alive = false;
        OnDeath?.Invoke();
    }
}
