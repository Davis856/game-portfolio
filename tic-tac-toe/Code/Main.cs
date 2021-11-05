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
    [SerializeField] private int xPoints = 0;
    [SerializeField] private int oPoints = 0;

    void Awake()
    {
        winnerAnim = winnerAnimator.GetComponent<Animation>();
        mBoard.Build(this);
        mTurn.text = "X's Turn";
    }

    void Update()
    {
        xScore.text = "X:" + xPoints;
        oScore.text = "O:" + oPoints;
    }

    public void Switch()
    {
        mTurnCount++;

        bool hasWinner = mBoard.CheckForWinner();

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
            if (GetTurnCharacter() == "X")
                xPoints++;
            else if (GetTurnCharacter() == "O")
                oPoints++;
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

        Time.timeScale = 0;
    }


    public void RestartGame()
    {
        //StartCoroutine(StartNewGame());
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


    /*private IEnumerator StartNewGame()
    {

    }*/

}
