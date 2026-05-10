using UnityEngine;
using Valve.VR;

public class Gun : MonoBehaviour
{
    public SteamVR_Action_Boolean m_FireAction;
    public SteamVR_Input_Sources handType;

    [SerializeField] GameObject Bullet, shootpoint, BulletDirection;

    private bool PickedUp { get; set; }

    public void EnableControls()
    {
        PickedUp = true;
    }

    public void DisableControls()
    {
        PickedUp = false;
    }

    private void Awake()
    {
        m_FireAction.AddOnStateDownListener(Pew, handType);
    }

    private void Pew(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (PickedUp)
        {
            Vector3 direction = (BulletDirection.transform.position - shootpoint.transform.position).normalized;
            System.Console.WriteLine("Peng");
            GameObject go = Instantiate(Bullet, shootpoint.transform.position, Quaternion.identity);
            go.GetComponent<Bullet>().direction = direction;
        }
    }
}
