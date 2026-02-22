using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class HPControl : MonoBehaviour
{
    int HP = 100;
    public static event Action<int> OnHPChange;
    public static event Action<bool> OnDeath;


    void OnDamage()
    {
        HP=HP-d;
        if (HP <= 0)
        {
            SceneManager.LoadScene("Ending");
        }
        OnHPChange?.Invoke(HP);
    }
    void OnHealth(int h)
    {
        HP = HP +h;
        if (HP > 100)
        {
            HP = 100;
        }
        OnHPChange?.Invoke(HP);
    }
}
