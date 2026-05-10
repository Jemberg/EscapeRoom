using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Room3_ButtonManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject handScanner;
    public int iterations;
    private int randomNum;
    private GameObject[] pillars = new GameObject[32];
    public TextMeshProUGUI TMP_IF;

    // Start is called before the first frame update
    void Start()
    {
        pillars = GameObject.FindGameObjectsWithTag("Pillar");
        Debug.Log(iterations.ToString());
        handScanner.SetActive(false);
        randomNum = Random.Range(1, 32);
        pillars[randomNum].transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (iterations > 0)
        {
            if (pillars[randomNum].transform.GetChild(0).GetComponent<Renderer>().material.color == Color.white)
            {
                iterations--;
                if (iterations == 0)
                {
                    handScanner.SetActive(true);
                }
                Debug.Log(iterations.ToString());
                randomNum = Random.Range(1, 32);
                pillars[randomNum].transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
            }
        }
        
    }
}
