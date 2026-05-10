using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    public TextMeshProUGUI currentAngleText;
    public TextMeshProUGUI leverToggleText;
    public GameObject lever;
    public UnityEvent eventOn;
    public UnityEvent eventOff;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var hinge = lever.GetComponent<HingeJoint>();
        currentAngleText.text = hinge.angle.ToString();
        // Debug.Log(hinge.angle);

        if (hinge.angle >= 34)
        {
            leverToggleText.color = new Color(222, 41, 22, 255);
            leverToggleText.text = "ON";
            eventOn.Invoke();

        } else if (hinge.angle <= -34)
        {
            leverToggleText.text = "OFF";
            leverToggleText.color = new Color(15, 98, 230, 255);
            eventOff.Invoke();
        }
    }
}
