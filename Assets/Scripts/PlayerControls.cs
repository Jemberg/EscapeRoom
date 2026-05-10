using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using Valve.VR;
using System;

public class PlayerControls : MonoBehaviour
{
    public List<string> Scenes;
    public List<int> Times;

    public GameObject Timer;

    public int MaxRooms;

    public readonly string DefaultScene = "TutorialRoom";

    public int Level { get; set; }

    public bool LevelCleared { get; set; } = false;

    private int[] roomOrder;

    public int TmpScore { get; set; } = 0;

    public int Score { get; set; } = 0;

    public int OldScore { get; set; } = 0;

    public int HighScore { get; set; } = 0;

    public int Difficulty { get; set; } = 1;

    public GameObject Hand;
    public SteamVR_Action_Boolean Button1;
    public SteamVR_Action_Boolean Button2;
    public SteamVR_Action_Boolean Button3;
    public SteamVR_Action_Boolean Button4;

    /// <summary>
    /// Input source.
    /// </summary>
    public SteamVR_Input_Sources handType;

    // Start is called before the first frame update
    void Start()
    {
        InitializeControls();
        Level = 0;

        //GenerateRoomOrder();
    }

    /// <summary>
    /// Function which generates the random order for the level selection
    /// </summary>
    private void GenerateRoomOrder()
    {
        // Generate random order of rooms
        roomOrder = new int[MaxRooms];
        int[] arr = Enumerable.Range(0, Scenes.Count).ToArray();
        RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
        arr = arr.OrderBy(x => Next(random)).ToArray();
        for (int i = 0; i < MaxRooms; i++) roomOrder[i] = arr[i];
    }

    /// <summary>
    /// Function which provides the possibility to actually get a random next number.
    /// </summary>
    /// <param name="random"></param>
    /// <returns></returns>
    static int Next(RNGCryptoServiceProvider random)
    {
        byte[] randomInt = new byte[4];
        random.GetBytes(randomInt);
        return Convert.ToInt32(randomInt[0]);
    }


    /// <summary>
    /// Function for code readability that initializes the default fixed control mapping.
    /// </summary>
    private void InitializeControls()
    {
        Button1.AddOnStateDownListener(Button1Action, handType);
        Button2.AddOnStateDownListener(Button2Action, handType);
        Button3.AddOnStateDownListener(Button3Action, handType);
        Button4.AddOnStateDownListener(Button4Action, handType);
    }


    /// <summary>
    /// B button release event.
    /// </summary>
    /// <param name="fromAction"></param>
    /// <param name="fromSource"></param>
    private void Button1Action(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

    }

    /// <summary>
    /// B button release event.
    /// </summary>
    /// <param name="fromAction"></param>
    /// <param name="fromSource"></param>
    private void Button2Action(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

    }

    /// <summary>
    /// B button release event.
    /// </summary>
    /// <param name="fromAction"></param>
    /// <param name="fromSource"></param>
    private void Button3Action(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

    }

    /// <summary>
    /// B button release event.
    /// </summary>
    /// <param name="fromAction"></param>
    /// <param name="fromSource"></param>
    private void Button4Action(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {

    }

    public void ChangeScene()
    {
        Transform pp = gameObject.transform;
        pp.position = new Vector3(0, pp.position.y, 0);

        TmpScore += GetLevelScore();

        if (Level == MaxRooms)
        {
            SceneManager.LoadScene(DefaultScene, LoadSceneMode.Single);
            Level = 0;
            OldScore = Score;
            Score = TmpScore;
            if (TmpScore > HighScore) HighScore = TmpScore;
            TmpScore = 0;
            //GenerateRoomOrder();
        }
        else
        {
            if (Level == 0) GenerateRoomOrder();
            Level++;
            int nextScene = roomOrder[Level - 1];
            Timer.GetComponent<Timer>().TargetTime = Times.ElementAt(nextScene) - ((Difficulty - 1) * 5);
            SceneManager.LoadScene(Scenes.ElementAt(nextScene), LoadSceneMode.Single);
        }
    }

    private int GetLevelScore()
    {
        int remainingTime = (int)Mathf.Round(Timer.GetComponent<Timer>().TargetTime);
        float scoreFactor = ((float)Difficulty / 10.0f - 0.1f) * 2.0f;
        float factoredScore = remainingTime * scoreFactor + remainingTime;
        return (int)Mathf.Round(factoredScore);
    }
}
