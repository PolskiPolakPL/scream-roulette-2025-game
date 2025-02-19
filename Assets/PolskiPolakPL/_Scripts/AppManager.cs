using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    //Singletons
    public static AppManager Instance;
    private void Awake()
    {
        if (Instance && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }

    public void ChangeScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void SetFPS(int newFPS)
    {
        Application.targetFrameRate = newFPS;
    }
}
