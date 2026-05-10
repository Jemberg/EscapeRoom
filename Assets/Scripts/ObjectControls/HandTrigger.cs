using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrigger : MonoBehaviour
{
    public string targetTag; // The tag of the object we want to detect collisions with

    // This function is called when the hand enters the collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider has the correct tag
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Hand entered the trigger of object with tag " + targetTag);
        }
    }

    // This function is called when the hand exits the collider
    private void OnTriggerExit(Collider other)
    {
        // Check if the collider has the correct tag
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Hand exited the trigger of object with tag " + targetTag);
        }
    }
}
