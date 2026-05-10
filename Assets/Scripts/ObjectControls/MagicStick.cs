using UnityEngine;
using Valve.VR;

public class MagicStick : MonoBehaviour
{
    public SteamVR_Action_Boolean m_FireAction;
    public SteamVR_Input_Sources handType;

    private bool PickedUp { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        InitializeControls();
        gameObject.GetComponent<Renderer>().material.color = Color.grey;
    }

    public void Enable()
    {
        PickedUp = true;
    }

    public void Disable()
    {
        PickedUp = false;
    }

    /// <summary>
    /// Function for code readability that initializes the default fixed control mapping.
    /// </summary>
    private void InitializeControls()
    {
        m_FireAction.AddOnStateDownListener(Button1ActionPress, handType);
        m_FireAction.AddOnStateUpListener(Button1ActionRelease, handType);
    }


    /// <summary>
    /// B button release event.
    /// </summary>
    /// <param name="fromAction"></param>
    /// <param name="fromSource"></param>
    private void Button1ActionPress(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (PickedUp)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }


    /// <summary>
    /// B button release event.
    /// </summary>
    /// <param name="fromAction"></param>
    /// <param name="fromSource"></param>
    private void Button1ActionRelease(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (PickedUp)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.grey;
        }
    }
}
