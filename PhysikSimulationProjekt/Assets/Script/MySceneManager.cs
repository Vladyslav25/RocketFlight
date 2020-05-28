using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public void StartClick()
    {
        ChangeScene("MainGame");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void ChangeScene(string _LevelName)
    {
        SceneManager.LoadScene(_LevelName);
        Debug.Log("New Game");
    }
}
