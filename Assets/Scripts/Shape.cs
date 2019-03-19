using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    public float speed = 1.0f;

    float lastMoveDown = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("a"))
        {
            transform.position += new Vector3(-1, 0, 0);

            Debug.Log(transform.position);

           // if (!IsInGrid())
          //  {
//transform.position += new Vector3(1, 0, 0);
          //  }
        }
        if (Input.GetKeyDown("d"))
        {
            transform.position += new Vector3(1, 0, 0);

            Debug.Log(transform.position);

           // if (!IsInGrid())
//{
//transform.position += new Vector3(-1, 0, 0);
//}
        }
        if (Input.GetKeyDown("s") || Time.time - lastMoveDown >= 1)
        {
            transform.position += new Vector3(0, -1, 0);

            Debug.Log(transform.position);

            // if (!IsInGrid())
            // {
            //transform.position += new Vector3(0, -1, 0);
            //}

            lastMoveDown = Time.time;
        }
        if (Input.GetKeyDown("w"))
        {
            transform.Rotate(0, 0, 90);

            Debug.Log(transform.position);

            if (!IsInGrid())
            {
                transform.Rotate(0, 0, -90);
            }
        }

    }

    public bool IsInGrid()
    {

        int childCount = 0;

        foreach(Transform childBlock in transform)
        {
            Vector2 vect = childBlock.position;
            childCount++;

            Debug.Log(childCount + " " + childBlock.position);

            if (!IsInBorder(vect))
            {
                return false;
            }
        }
        return true;
    }

    public static bool IsInBorder(Vector2 pos)
    {
        return ((int)pos.x >= -0.73 && (int)pos.x <= 10.31 && (int)pos.y >= -10.45);
    }
}
