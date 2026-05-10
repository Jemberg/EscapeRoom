using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public GameObject object1; // Drag the first object into this field in the Inspector
    public GameObject object2; // Drag the second object into this field in the Inspector
    public GameObject prefabToSpawn;

   // void OnCollisionEnter2D(Collision2D collision)
   // {
       // if (collision.gameObject == object1 || collision.gameObject == object2)
       // {
           // Modify the position and rotation of the prefab
       // Vector3 spawnPosition = transform.position + new Vector3(5, 1, 0); // move the prefab 1 unit to the right and 1 unit up
       // Quaternion spawnRotation = transform.rotation * Quaternion.Euler(0, 0, 0); // rotate the prefab 90 degrees around the z axis

        // Spawn the prefab at the modified position and rotation
       // GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
       // Debug.Log("A HandScanner has been spawned!");
      //  }

     
   // }

      // void OnCollisionEnter(Collision collision)
    //{
        // Modify the position and rotation of the prefab
        //Vector3 spawnPosition = transform.position + new Vector3(5, 1, 0); // move the prefab 1 unit to the right and 1 unit up
        //Quaternion spawnRotation = transform.rotation * Quaternion.Euler(0, 0, 0); // rotate the prefab 90 degrees around the z axis

        // Spawn the prefab at the modified position and rotation
        //GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
        //Debug.Log("A HandScanner has been spawned!");
      //  Debug.Log("Collision detected with object: " + collision.gameObject.name);
    //}

    void OnTriggerEnter(Collider collider)
    {
        prefabToSpawn.SetActive(true);
         // Modify the position and rotation of the prefab
        Vector3 spawnPosition = transform.position + new Vector3(6, -3.4f, 0); // move the prefab 1 unit to the right and 1 unit up
        Quaternion spawnRotation = transform.rotation * Quaternion.Euler(0, 90, 0); // rotate the prefab 90 degrees around the z axis

        // Spawn the prefab at the modified position and rotation
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
        Debug.Log("A HandScanner has been spawned!");
        Debug.Log("Object entered trigger: " + collider.gameObject.name);
    }
}
