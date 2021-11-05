using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    // Cell properties
    public Text mLabel;
    public Button mButton;
    public Main mMain;
    public Text mTurn;

    public void Fill()
    {
        mButton.interactable = false;

        mLabel.text = mMain.GetTurnCharacter();

        mMain.Switch();
    }
}
