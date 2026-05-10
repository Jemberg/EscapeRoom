using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public Material sphereMaterial;

    public void SpawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.localPosition = new Vector3(-3.73f, 3.433826f, -11.375f);

        sphere.gameObject.GetComponent<Renderer>().material = sphereMaterial;
        sphere.gameObject.GetComponent<Collider>().material.bounciness = 0.25f;

        sphere.AddComponent<Rigidbody>();
        Debug.Log("A Sphere has been spawned!");
        Destroy(sphere.gameObject, 15.0f);
    }
}
