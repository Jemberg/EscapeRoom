using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalloon : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject Button;
    public void SpawnTheBasketball()
        {
            // Modify the position and rotation of the prefab
            Vector3 spawnPosition = transform.position + new Vector3(-6, 3, 1); // move the prefab 1 unit to the right and 1 unit up
            Quaternion spawnRotation = transform.rotation * Quaternion.Euler(0, 0, 90); // rotate the prefab 90 degrees around the z axis

            // Spawn the prefab at the modified position and rotation
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
            Debug.Log("A Sphere has been spawned!");
            Destroy(Button);
            
        }
}
