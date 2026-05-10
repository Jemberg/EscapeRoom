using UnityEngine;

public class RadioScript : MonoBehaviour
{
    private bool _enabled { get; set; } = true;
    public AudioSource audioSource;
    public AudioClip bgm1;

    public bool Enabled
    {
        get
        {
            return _enabled;
        }
        set
        {
            audioSource.enabled = value;
            _enabled = value;
            if (_enabled) audioSource.Play();
        }
    }

    private void Start()
    {
        audioSource.clip = bgm1;
        if (Enabled) audioSource.Play();
    }

    public void PickedUp()
    {
        Enabled = !Enabled;
    }
}
