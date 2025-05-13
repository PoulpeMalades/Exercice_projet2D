using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryScreen : MonoBehaviour
{
    void Update()
    {
        
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
