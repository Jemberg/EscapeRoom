using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonGameForce : MonoBehaviour
{
    public GameObject hallway;
    public GameObject balloon;

    void Update()
    {
        if (balloon.GetComponent<Collider>().bounds.Intersects(hallway.GetComponent<Collider>().bounds))
        {
            Debug.Log("Ballon und Flur berühren sich!");
        }
    }


    void OnTriggerEnter(Collider collider)
    {
         Rigidbody rb = balloon.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0, 500, 0));

            // Zufällige Störkraft nach links oder rechts
            if (Random.Range(0, 2) == 0)
            {
                rb.AddForce(new Vector3(0, 0, -400));
            }
            else
            {
                rb.AddForce(new Vector3(0, 0, 400));
            }
    }
}
