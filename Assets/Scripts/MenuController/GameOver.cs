using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
