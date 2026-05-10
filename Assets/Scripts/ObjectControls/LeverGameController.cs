using UnityEngine;
using TMPro;

public class LeverGameController : MonoBehaviour
{
    public Animator animator1;

    public Animator animator2;

    public TextMeshProUGUI Monitor;

    public GameObject HandScanner;

    public GameObject RotatingDoor;

    public AudioSource asRotate;
    public AudioSource asSlide;

    private int Step = 0;

    private int Status = 1;

    private bool SlideDoorsOpened = false;

    public bool ObjectsCollected = false;

    private bool lastLeft = false;

    public void SlideDoorsOpen()
    {
        if (Step == 0) Step = 1;
        if (Step == 1) Monitor.text = "Rotate the middle part to get the Stuff out!";
        if (!SlideDoorsOpened) animator1.SetTrigger("SlideOpen");
        if (!SlideDoorsOpened) asSlide.Play();
        SlideDoorsOpened = true;
    }

    public void SlideDoorsClose()
    {
        if (SlideDoorsOpened) animator1.SetTrigger("SlideClose");
        if (SlideDoorsOpened) asSlide.Play();
        SlideDoorsOpened = false;
    }

    public void RotateRightHalf()
    {
        if (Status == 1)
        {
            animator2.SetTrigger("Step225Fore");
            Status = 2;
            lastLeft = true;
            asRotate.Play();
        }
    }

    public void RotateRightFull()
    {
        if (Status == 2)
        {
            if (lastLeft) animator2.SetTrigger("Step270Fore");
            else animator2.SetTrigger("Step270Fore2");
            if (Step == 1) Step = 2;
            if (Step == 2) Monitor.text = "Now put 3 samples of the Stuff into the tiny brown box!";
            Status = 3;
            asRotate.Play();
        }
    }

    public void RotateLeftHalf()
    {
        if (Status == 2)
        {
            animator2.SetTrigger("Step180Back");
            Status = 1;
            asRotate.Play();
        }
    }

    public void RotateLeftFull()
    {
        if (Status == 3)
        {
            animator2.SetTrigger("Step225Back");
            Status = 2;
            lastLeft = false;
            asRotate.Play();
        }
    }

    public void ActivateHandScanner()
    {
        if (ObjectsCollected && !SlideDoorsOpened)
            HandScanner.SetActive(true);
    }

    public void StuffInBoxes()
    {
        ObjectsCollected = true;
        if (Step == 2 || Step == 1) Step = 3;
        if (Step == 3) Monitor.text = "Now Close the Slidedoors and search for the Lever to leave this room!";
    }

    public void Funny()
    {
        if (!Monitor.text.Contains("wrong")) Monitor.text = Monitor.text + " \n Thats the wrong lever!";
    }
}
