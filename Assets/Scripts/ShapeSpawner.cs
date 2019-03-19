using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawner : MonoBehaviour {

    public GameObject[] shapes;

    public void SpawnShape()
    {
        int shapeIndex = Random.Range(0,5);

        Instantiate(shapes[shapeIndex], transform.position ,Quaternion.identity);
    }

	// Use this for initialization
	void Start () {
        SpawnShape();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
