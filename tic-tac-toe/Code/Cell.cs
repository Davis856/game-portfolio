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
    public GameBoard mBoard;
    public static bool mMulti;

    public void Fill()
    {
        mButton.interactable = false;

        if (mMulti == false)
        {
            if (mMain.GetTurnCharacter() == "X")
                mLabel.text = mMain.GetTurnCharacter();
        }
        else if (mMulti == true)
        {
            if (mMain.GetTurnCharacter() == "X")
                mLabel.text = "X";
            else if (mMain.GetTurnCharacter() == "O")
                mLabel.text = "O";
        }
        mMain.Switch();
    }
}
