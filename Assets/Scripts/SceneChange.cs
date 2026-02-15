using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeToLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }

    void OnChangeGameplay()
    {
        ChangeToLevel();
    }

    void OnClose()
    {
        Application.Quit();
    }
}