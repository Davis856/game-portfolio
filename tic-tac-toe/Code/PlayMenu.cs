using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void Singleplayer()
    {
        SceneManager.LoadScene("MainGame");
    }

    /*
    public void Multiplayer()
    {
        SceneManager.LoadScene("Multiplayer");
    }
    */

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
