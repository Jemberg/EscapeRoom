using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScannerPicker : MonoBehaviour
{
    private GameObject[] exits;
    private bool isAdjusted;
    // Update is called once per frame

    void Start()
    {
        isAdjusted = false;
    }

    void Update()
    {
        exits = GameObject.FindGameObjectsWithTag("HandScanner");

        // Debug.Log("There are " + exits.Length + " exits in this level currently");
        // Deletes all but one handScanner.
        for (int i = 0; i < exits.Length - 1; i++)
        {
            Destroy(exits[i]);
            Debug.Log("Exit number " + i + " has been disabled.");
        }

        float xPos = exits[0].transform.position.x;
        float zPos = exits[0].transform.position.z;
        Vector3 newPos = new Vector3(xPos, (float)0.5, zPos);
        exits[0].transform.position = newPos;
    }
}
