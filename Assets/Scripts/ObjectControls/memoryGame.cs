using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memoryGame : MonoBehaviour
{
    public List<Material> materialList = new List<Material>();
    public GameObject objectToMaterial;
    public float moveDistance = 50f; // distance to move object
    public List<Material> OrderList = new List<Material>();
    List<Material> materialToCompare = new List<Material>();
    public GameObject prefabToSpawn;
    //public memoryButton MemoryButton;
    public AudioSource switchingSound;
    public AudioSource failedSound;
    public AudioSource victorySound;
    int reset = 0;
    
    
    


    void Start()
    {
        // Shuffle the list
        for (int i = 0; i < materialList.Count; i++)
        {
            Material temp = materialList[i];
            int randomIndex = Random.Range(i, materialList.Count);
            materialList[i] = materialList[randomIndex];
            materialList[randomIndex] = temp;
        }
        StartCoroutine(ChangeMaterial());
    }

    public void RegisterButton(Material mat)
    {
        if (materialToCompare.Contains(mat))
            {
                // Material ist bereits in der Liste
            }
        else
            {
                materialToCompare.Add(mat);
                // Material ist nicht in der Liste und wurde hinzugefügt
            }
        //Debug.Log(materialToCompare.Count);
    }

    IEnumerator ChangeMaterial()
    {
        objectToMaterial.GetComponent<Renderer>().material = materialList[0];
        yield return new WaitForSeconds(4);
        for (int i = 0; i <= materialList.Count; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                //Debug.Log(j);
                //Debug.Log(materialList[j]);
                if(reset == 1)
                {
                    Debug.Log("neustart");
                    materialToCompare.Clear();
                        for (int b = 0; b < materialList.Count; b++)
                        {
                            Material temp = materialList[b];
                            int randomIndex = Random.Range(b, materialList.Count);
                            materialList[b] = materialList[randomIndex];
                            materialList[randomIndex] = temp;
                        }
                    
                    j = 0;
                    i = 0;
                    reset = 0;
                }
                objectToMaterial.GetComponent<Renderer>().material = materialList[j];
                switchingSound.Play();
                materialToCompare.Clear();
                yield return new WaitForSeconds(2);

            }
            //objectToMaterial.transform.Translate(Vector3.down * moveDistance * Time.deltaTime);//backward
            objectToMaterial.transform.Translate(Vector3.down * moveDistance * Time.fixedDeltaTime);//backward
            for (int a = 0; a <= i; a++)
            {
                while (a == materialToCompare.Count)
                {
                    yield return new WaitForSeconds(1);
                }
                if (a < materialList.Count && a < materialToCompare.Count)
                {
                    //Debug.Log("Element Farbe wird verglichen");
                    //Debug.Log(a);
                    if (materialList[a].color == materialToCompare[a].color)
                    {
                        // Elemente sind gleich, Schleife läuft weiter
                        //Debug.Log("gleiche Elemente");
                        //Debug.Log(materialList[a].color);
                        //Debug.Log(materialToCompare[a].color);
                        //Debug.Log(materialList[a]);
                        //Debug.Log(materialToCompare[a]);
                        if (a == 6)
                        {
                            prefabToSpawn.SetActive(true);
                            //victorySound.Play();
                            Vector3 spawnPosition = new Vector3(-4, 0.41f, 1); // move the prefab 1 unit to the right and 1 unit up
                            Quaternion spawnRotation =Quaternion.Euler(0, 90, 0); // rotate the prefab 90 degrees around the z axis
                            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
                            //Debug.Log("A HandScanner has been spawned!");
                            //Debug.Log("Object entered trigger: " + GetComponent<Collider>().gameObject.name); 
                        }
                    }
                    else
                    {
                        // Elemente sind ungleich, Schleife bricht ab
                        Debug.Log("You failed");
                        failedSound.Play();
                        //Debug.Log(a);
                        //Debug.Log(materialList[a].color);
                        //Debug.Log(materialToCompare[a].color);
                        reset = 1;
                        i = 8;
                        a=9;
                    }
                }
            }
            //Debug.Log("forward");
            materialToCompare.Clear();
            yield return new WaitForSeconds(0.5f);
            //objectToMaterial.transform.Translate(Vector3.up * moveDistance * Time.deltaTime);//forward
            objectToMaterial.transform.Translate(Vector3.up * moveDistance * Time.fixedDeltaTime);//forwardh
        }
    }

}
