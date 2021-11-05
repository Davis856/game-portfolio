using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public GameObject mCellPrefab;
    public GameObject mXLine;
    public GameObject mYLine;
    public GameObject mHorLine;

    private Cell[] mCells = new Cell[9];

    // We create cells in the grid
    public void Build(Main main)
    {
        for (int i = 0; i <= 8; i++)
        {
            GameObject newCell = Instantiate(mCellPrefab, transform);

            mCells[i] = newCell.GetComponent<Cell>();
            mCells[i].mMain = main;
        }
    }

    public bool CheckForWinner()
    {
        int i = 0;
        // Horizontal check
        for (i = 0; i <= 6; i += 3)
        {
            if (CheckValues(i, i + 1, i + 2))
                return true;
        }
        // Vertical check
        for (i = 0; i <= 2; i++)
        {
            if (CheckValues(i, i + 3, i + 6))
                return true;
        }

        // left Diagonal check
        if (CheckValues(0, 4, 8))
            return true;

        // right Diagonal check
        if (CheckValues(2, 4, 6))
            return true;

        return false;
    }

    private bool CheckValues(int firstIndex, int secondIndex, int thirdIndex)
    {
        string firstValue = mCells[firstIndex].mLabel.text;
        string secondValue = mCells[secondIndex].mLabel.text;
        string thirdValue = mCells[thirdIndex].mLabel.text;

        if (firstValue == "" || secondValue == "" || thirdValue =="")
            return false;

        if (firstValue == secondValue && firstValue == thirdValue)
            return true;
        else
            return false;
    }


    public void EndGame()
    {
        foreach (Cell cell in mCells)
        {
            cell.mButton.interactable = false;
        }
    }

    public void ResetBoard()
    {
        foreach(Cell cell in mCells)
        {
            cell.mLabel.text = "";
            cell.mButton.interactable = true;
            Time.timeScale = 1;
        }
    }

}
