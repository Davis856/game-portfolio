using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject exitPopup;
    public GameObject Background;


    //TODO : modify image alpha using code
    public void ExitPopup()
    {
        // TO FIX
        exitPopup.SetActive(true);
        
    }

    public void NoExit()
    {
        exitPopup.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
