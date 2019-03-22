using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour {

    public static Transform[,] gameBoard = new Transform[10, 20];

    public static void PrintArray()
    {
        string arrayOutput = "";

        int iMax = gameBoard.GetLength(0) - 1;
        int jMax = gameBoard.GetLength(1) - 1;

        for(int j = jMax; j >= 0; j--)
        {
            for(int i = 0; i <= iMax; i++)
            {
                if (gameBoard[i, j] == null)
                {
                    arrayOutput += "N";
                }
                else
                {
                    arrayOutput += "X";
                }
            }

            arrayOutput += "\n \n";
        }

        var myArrayComp = GameObject.Find("MyArray").GetComponent<Text>();
        myArrayComp.text = arrayOutput;
    }

}
