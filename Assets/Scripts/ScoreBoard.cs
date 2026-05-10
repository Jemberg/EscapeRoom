using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI OldScore;
    public TextMeshProUGUI HighScore;

    private void Start()
    {
        PlayerControls player = GameObject.Find("Player").GetComponent<PlayerControls>();
        OldScore.text = player.OldScore + "";
        Score.text = player.Score + "";
        HighScore.text = player.HighScore + "";
    }
}
