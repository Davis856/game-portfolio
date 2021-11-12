using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void Multiplayer()
    {
        SceneManager.LoadScene("MainGame");
        Cell.mMulti = true;
    }

    
    public void Singleplayer()
    {
        SceneManager.LoadScene("MainGame");
        Cell.mMulti = false;
    }
    

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
