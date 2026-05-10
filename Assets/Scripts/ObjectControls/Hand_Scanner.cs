using System;
using UnityEngine;

public class Hand_Scanner : MonoBehaviour
{
    // The object that this script is attached to
    private GameObject thisObject;

    public GameObject HandPanel;

    // The object that we want to check for collisions with
    public GameObject LeftHand { get; set; }

    // The object that we want to check for collisions with
    public GameObject RightHand { get; set; }

    // A variable to keep track of the time that the objects have been colliding
    private float collisionTimer = 0.0f;

    // The threshold time for triggering the action
    public float thresholdTime = 2.0f;

    // The material to apply to the object when the threshold time is reached
    public Material newMaterial;

    void Start()
    {
        // Get a reference to the object that this script is attached to
        thisObject = gameObject;
        LeftHand = GameObject.Find("LeftHand");
        RightHand = GameObject.Find("RightHand");
    }

    void Update()
    {
        // Check if this object is colliding with the other object
        if (thisObject.GetComponent<Collider>().bounds.Intersects(LeftHand.GetComponent<Collider>().bounds) || thisObject.GetComponent<Collider>().bounds.Intersects(RightHand.GetComponent<Collider>().bounds))
        {
            // If they are colliding, increment the collision timer
            collisionTimer += Time.deltaTime;
            Material mat = HandPanel.GetComponent<MeshRenderer>().material;
            Color colors = mat.color;
            mat.SetColor("_Color", new Color(colors.r, colors.g, 1.0f - Mathf.Round(255 / thresholdTime * collisionTimer) / 255, colors.a));
            // Check if the collision timer has reached the threshold time
            if (collisionTimer >= thresholdTime)
            {
                //Debug.Log("Hand is Scanned!");
                GameObject.Find("Player").GetComponent<PlayerControls>().ChangeScene();
            }
        }
        else
        {
            Material mat = HandPanel.GetComponent<MeshRenderer>().material;
            Color colors = mat.color;
            mat.SetColor("_Color", new Color(colors.r, colors.g, 1, colors.a));
            // If they are not colliding, reset the collision timer
            collisionTimer = 0.0f;

        }
    }
}

