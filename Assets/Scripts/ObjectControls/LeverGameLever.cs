using UnityEngine;
using UnityEngine.Events;

public class LeverGameLever : MonoBehaviour
{
    public GameObject lever;
    public UnityEvent eventOn;
    public UnityEvent eventOff;

    // Update is called once per frame
    void Update()
    {
        var hinge = lever.GetComponent<HingeJoint>();
        // Debug.Log(hinge.angle);

        if (hinge.angle >= 34)
        {
            eventOn.Invoke();
        }
        else if (hinge.angle <= -34)
        {
            eventOff.Invoke();
        }
    }
}
