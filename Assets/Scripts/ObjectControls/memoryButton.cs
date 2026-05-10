using UnityEngine;

public class memoryButton : MonoBehaviour
{
    //private bool ButtonPressed = false;

    public GameObject MemoryGame;

    public void MemoryButtonPressed()
    {
        Debug.Log(gameObject.name + " is pressed!");
        MemoryGame.GetComponent<memoryGame>().RegisterButton(gameObject.GetComponent<MeshRenderer>().material);
    }
}
