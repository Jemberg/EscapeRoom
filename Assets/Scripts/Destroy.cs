using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public void ButtonClick(GameObject clickedObject)
    {
        clickedObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white; // Doesn't actually destroy anything, just makes the object white again. Sorry for the clickbait.
    }
}
