using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameOver GameOver;
    private string maxPlatform = "VOUS ÊTES MORT";

    public void gameOver()
    {
        GameOver.Setup(maxPlatform);
    }
}
