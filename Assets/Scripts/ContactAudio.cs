using UnityEngine;

public class ContactAudio : MonoBehaviour
{
    private void Start()
    {
        AudioSource AS = gameObject.GetComponent<AudioSource>();
        AS.spatialBlend = 1.0f;
        AS.maxDistance = 1.5f;
        AS.playOnAwake = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.get);
        if (!collision.gameObject.GetComponentInParent<PlayerControls>())
            gameObject.GetComponent<AudioSource>().Play();
    }
}
