using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject TimerPrefab;
    public float TargetTime;
    private float refTime;

    public AudioSource audioSource;
    public AudioClip clip;

    private bool IncreaseVolume = false;
    private float clipLength;

    private void Start()
    {
        refTime = TargetTime;
        clipLength = audioSource.clip.length;
        audioSource.clip = clip;
    }

    void Update()
    {
        TargetTime -= Time.deltaTime;
        if (clipLength > TargetTime && IncreaseVolume == false)
        {
            IncreaseVolume = true;
            audioSource.Play();
        }
        var timeSpan = TimeSpan.FromSeconds(TargetTime);
        TimerPrefab.GetComponent<TMP_Text>().text = timeSpan.Minutes.ToString() + ":" + timeSpan.Seconds.ToString();
        if (TargetTime <= 0.0f) TimerEnded();
        if (IncreaseVolume) audioSource.volume = (refTime - TargetTime) * (1.0f / refTime);
    }

    void TimerEnded()
    {
        PlayerControls Player = GameObject.Find("Player").GetComponent<PlayerControls>();
        if (Player.Level == 0) TargetTime = 60.00f;
        else
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        PlayerControls Player = GameObject.Find("Player").GetComponent<PlayerControls>();
        Player.Level = 0;
        Player.TmpScore = 0;
        SceneManager.LoadScene(Player.DefaultScene, LoadSceneMode.Single);
    }
}