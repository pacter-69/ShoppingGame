using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (GameObject.Find("SceneChange") != gameObject) { 
            Destroy (GameObject.Find("SceneChange"));
        }
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