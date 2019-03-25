using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shape : MonoBehaviour
{

    public float speed = 1.0f;

    float lastMoveDown = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (!IsInGrid())
            {
                transform.position += new Vector3(1, 0, 0);

            }
            else
            {
                UpdateGameBoard();

            }

            Debug.Log(transform.position);
        }

        if (Input.GetKeyDown("d"))
        {
            transform.position += new Vector3(1, 0, 0);

            if (!IsInGrid())
            {
                transform.position += new Vector3(-1, 0, 0);

            }
            else
            {
                UpdateGameBoard();

            }

            Debug.Log(transform.position);
        }   

        if (Input.GetKeyDown("s") || Time.time - lastMoveDown >= 1)
        {
            transform.position += new Vector3(0, -1, 0);

            if (!IsInGrid())
            {
                transform.position += new Vector3(0, 1, 0);

                // Delete all full rows found
                bool rowDeleted = GameBoard.DeleteAllFullRows();

                // If you deleted a row verify that another doesn't
                // exist
                if (rowDeleted)
                {
                    GameBoard.DeleteAllFullRows();

                    //creaseTextUIScore();
                }

                // Disconnect the script actions from the shape
                enabled = false;

                // Spawn another shape
                FindObjectOfType<ShapeSpawner>().SpawnShape();
            }
            else
            {
                UpdateGameBoard();
            }

            lastMoveDown = Time.time;
        }

        if (Input.GetKeyDown("w"))
        {
            transform.Rotate(0,0,90);

            if (!IsInGrid())
            {
                transform.Rotate(0, 0, -90);

            }
            else
            {
                UpdateGameBoard();

            }

            Debug.Log(transform.position);
        }


        if (Input.GetKeyDown("e"))
        {
            transform.Rotate(0, 0, -90);

            if (!IsInGrid())
            {
                transform.Rotate(0, 0, 90);

            }
            else
            {
                UpdateGameBoard();

            }

            Debug.Log(transform.position);
        }
    }
    public bool IsInGrid()
    {
        foreach (Transform childBlock in transform)
        {
            Vector2 vect = RoundVector(childBlock.position);
            if (!IsInBorder(vect))
            {
                return false;
            }

            if(GameBoard.gameBoard[(int)vect.x, (int)vect.y] != null &&  GameBoard.gameBoard[(int)vect.x, (int)vect.y].parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    public Vector2 RoundVector(Vector2 vect)
    {
        return new Vector2(Mathf.Round(vect.x), Mathf.Round(vect.y));
    }

    public static bool IsInBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x <= 8 && (int)pos.y >= 0);
    }

    public void UpdateGameBoard()
    {
        for (int y = 0; y < 20; ++y)
        {
            for (int x = 0; x < 10; ++x)
            {
                if (GameBoard.gameBoard[x, y] != null && GameBoard.gameBoard[x, y].parent == transform)
                {
                    GameBoard.gameBoard[x, y] = null;
                }
            }
        }

        foreach(Transform childBlock in transform)
        {
            Vector2 vect = RoundVector(childBlock.position);

                GameBoard.gameBoard[(int)vect.x, (int)vect.y] = childBlock;

                Debug.Log("Cube At : " + vect.x + " " + vect.y);
        }

        //GameBoard.PrintArray();
    }
    void IncreaseTextUIScore()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score++;

        textUIComp.text = score.ToString();
    }
}
