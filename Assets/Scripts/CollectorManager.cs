using UnityEngine;
using TMPro;

public class CollectorManager : MonoBehaviour
{
    public GameObject HandScanner;

    public GameObject ToCollect;

    public GameObject NotToCollect;

    public TextMeshProUGUI CollectionBoard1;
    public TextMeshProUGUI CollectionBoard2;

    public GameObject Room;

    private int Collected = 0;

    float x, y, z;
    Vector3 pos;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ToCollect")
            Collected++;
        if (collision.gameObject.tag == "NotToCollect")
            Collected--;
        UpdateScore();
    }

    private void UpdateScore()
    {
        CollectionBoard1.text = Collected + "/5";
        CollectionBoard2.text = Collected + "/5";
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ToCollect")
            Collected--;
        if (collision.gameObject.tag == "NotToCollect")
            Collected++;
        UpdateScore();
    }

    private void Update()
    {
        if (Collected >= 5)
        {
            HandScanner.SetActive(true);
        }
    }


    void Start()
    {
        InvokeRepeating("SpawnCollectible", 2.0f, 0.5f);
    }

    void SpawnCollectible()
    {
        float rand = Random.value;
        GameObject go;
        if (rand <= .8f)
            go = NotToCollect;
        else
        {
            go = ToCollect;
        }
        x = Random.Range(-14f, 14f);
        y = 5;
        z = Random.Range(-14f, 14f);
        pos = new Vector3(x, y, z);

        Instantiate(go, pos, Quaternion.identity, Room.transform);
    }
}
