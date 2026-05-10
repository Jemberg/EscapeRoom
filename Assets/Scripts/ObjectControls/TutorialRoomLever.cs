using UnityEngine;
using TMPro;

public class TutorialRoomLever : MonoBehaviour
{
    public GameObject lever;
    public TextMeshProUGUI Difficulty;

    private bool canTurnOn = true;
    private bool canTurnOff = true;

    private bool _isOn { get; set; } = false;
    private bool isOn
    {
        get
        {
            return _isOn;
        }
        set
        {
            PlayerControls player = GameObject.Find("Player").GetComponent<PlayerControls>();
            player.Difficulty += isOn ? -1 : 1;
            player.MaxRooms += isOn ? -1 : 1;
            Debug.Log(player.Difficulty);
            Difficulty.text = player.Difficulty == 1 ? "Easy" : player.Difficulty == 2 ? "Medium" : "Hard";
            _isOn = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var hinge = lever.GetComponent<HingeJoint>();
        // Debug.Log(hinge.angle);

        if (hinge.angle >= 34 && !isOn && canTurnOn)
        {
            isOn = true;
            canTurnOn = false;
            canTurnOff = true;
        }

        else if (hinge.angle <= -34 && isOn && canTurnOff)
        {
            isOn = false;
            canTurnOn = true;
            canTurnOff = false;
        }
    }
}
