using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameBoard mBoard;

    public GameObject mWinner;

    public Text mTurn;
    public Text xScore;
    public Text oScore;

    public Animator winnerAnimator;
    private Animation winnerAnim;

    private bool mXTurn = true;
    private int mTurnCount = 0;


    //TODO Create save/load system using these
    private int xPoints;
    private int oPoints;
    private int xPointsMP;
    private int oPointsMP;

    void Awake()
    {
        winnerAnim = winnerAnimator.GetComponent<Animation>();
        mBoard.Build(this);
        mTurn.text = "X's Turn";
        if (Cell.mMulti == false)
        {
            xPoints = PlayerPrefs.GetInt("xPoints");
            oPoints = PlayerPrefs.GetInt("oPoints");
            xScore.text = "X:" + PlayerPrefs.GetInt("xPoints");
            oScore.text = "O:" + PlayerPrefs.GetInt("oPoints");
        }
        else if(Cell.mMulti == true)
        {
            xPointsMP = PlayerPrefs.GetInt("xPointsMP");
            oPointsMP = PlayerPrefs.GetInt("oPointsMP");
            xScore.text = "X:" + PlayerPrefs.GetInt("xPointsMP");
            oScore.text = "O:" + PlayerPrefs.GetInt("oPointsMP");
        }
    }

    void Update()
    {
        if(Cell.mMulti == false)
        {
            xScore.text = "X:" + PlayerPrefs.GetInt("xPoints");
            oScore.text = "O:" + PlayerPrefs.GetInt("oPoints");
        }
        else if(Cell.mMulti == true)
        {
            xScore.text = "X:" + PlayerPrefs.GetInt("xPointsMP");
            oScore.text = "O:" + PlayerPrefs.GetInt("oPointsMP");
        }
    }

    public void Switch()
    {
        mTurnCount++;

        bool hasWinner = mBoard.CheckForWinner();

        if(GetTurnCharacter() == "X" && hasWinner == false && mTurnCount !=9 && Cell.mMulti == false)
            StartCoroutine(WaitABit());

        if (hasWinner || mTurnCount == 9)
        {
            // End Game
            StartCoroutine(EndGame(hasWinner));

            return;
        }

        mXTurn = !mXTurn;
    }

    public string GetTurnCharacter()
    {
        if(mXTurn)
        {
            mTurn.text = "O's Turn";
            return "X";
        }
        else
        {
            mTurn.text = "X's Turn";
            return "O";
        }
    }

    private IEnumerator EndGame(bool hasWinner)
    {
        mBoard.EndGame();

        Text winnerLabel = mWinner.GetComponentInChildren<Text>();

        if(hasWinner)
        {
            winnerLabel.text = GetTurnCharacter() + " " + "Won!";
            //easy save system - to be turned into serializeField
            if (Cell.mMulti == false)
            {
                if (GetTurnCharacter() == "X")
                {
                    xPoints++;
                    Debug.Log(xPoints);
                    PlayerPrefs.SetInt("xPoints", xPoints);
                }
                else if (GetTurnCharacter() == "O")
                {
                    oPoints++;
                    Debug.Log(oPoints);
                    PlayerPrefs.SetInt("oPoints", oPoints);
                }
            }
            else if (Cell.mMulti == true)
            {
                if (GetTurnCharacter() == "X")
                {
                    xPointsMP++;
                    PlayerPrefs.SetInt("xPointsMP", xPointsMP);
                }
                else if (GetTurnCharacter() == "O")
                {
                    oPointsMP++;
                    PlayerPrefs.SetInt("oPointsMP", oPointsMP);
                }
            }
        }
        else
        {
            winnerLabel.text = "Draw!";
        }

        //TODO bugs sometimes, should check for a fix
        mWinner.SetActive(true);

        winnerAnim.Play("WinnerSlide");

        WaitForSeconds wait = new WaitForSeconds(1.5f);
        yield return wait;

    }

    private IEnumerator WaitABit()
    {
        WaitForSeconds waitaBit = new WaitForSeconds(1.0f);
        yield return waitaBit;

        mBoard.ComputerMoves();
        Switch();
    }

    public void RestartGame()
    {
        mBoard.ResetBoard();
        mTurnCount = 0;
        mTurn.text = "X's Turn";
        mXTurn = true;
        mWinner.SetActive(false);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
