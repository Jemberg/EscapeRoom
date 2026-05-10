using UnityEngine;

public class LeverGameCollector : MonoBehaviour
{
    private int Collected = 0;

    public LeverGameController controller;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ToCollect")
            Collected++;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ToCollect")
            Collected--;
    }

    private void Update()
    {
        if (Collected >= 3 && !controller.ObjectsCollected)
        {
            controller.StuffInBoxes();
        }
    }
}

