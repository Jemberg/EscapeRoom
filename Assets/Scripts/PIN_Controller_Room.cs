using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class PIN_Controller_Room : MonoBehaviour
{
    public TextMeshProUGUI TMP_IF;
    public GameObject handScanner;

    private GameObject[] plates = new GameObject[100];

    private int firstNum;
    private int secondNum;
    private int thirdNum;
    private int fourthNum;

    private TextMeshProUGUI plate1;
    private TextMeshProUGUI plate2;
    private TextMeshProUGUI plate3;
    private TextMeshProUGUI plate4;

    private string numStr;
    private string input;

    public TextMeshProUGUI debugPlate1;
    public TextMeshProUGUI debugPlate2;
    public TextMeshProUGUI debugPlate3;
    public TextMeshProUGUI debugPlate4;

    void Start()
    {
        plates = GameObject.FindGameObjectsWithTag("Plates");
        Debug.Log("Plates in map: " + plates.Length);

        // Generates 4 random numbers.
        var randomPin1 = Random.Range(1, 9);
        var randomPin2 = Random.Range(1, 9);
        var randomPin3 = Random.Range(1, 9);
        var randomPin4 = Random.Range(1, 9);

        firstNum = randomPin1;
        secondNum = randomPin2;
        thirdNum = randomPin3;
        fourthNum = randomPin4;

        // Used for debugging purposes.
        debugPlate1.text = randomPin1.ToString();
        debugPlate2.text = randomPin2.ToString();
        debugPlate3.text = randomPin3.ToString();
        debugPlate4.text = randomPin4.ToString();

        // Generates 4 random plate numbers.
        List<int> listNumbers = new List<int>();
        int number;
        for (int i = 0; i < 4; i++)
        {
            do
            {
                number = Random.Range(1, plates.Length);
            } while (listNumbers.Contains(number));
            listNumbers.Add(number);
        }

        var random1 = listNumbers[0];
        var random2 = listNumbers[1];
        var random3 = listNumbers[2];
        var random4 = listNumbers[3];

        Debug.Log("First Number: " + random1.ToString());
        Debug.Log("Second Number: " + random2.ToString());
        Debug.Log("Third Number: " + random3.ToString());
        Debug.Log("Fourth Number: " + random4.ToString());

        // finds the plates selected via the generated random numbers.
        plate1 = plates[random1].transform.GetChild(0).GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI; // = firstNum.ToString();
        plate2 = plates[random2].transform.GetChild(0).GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        plate3 = plates[random3].transform.GetChild(0).GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        plate4 = plates[random4].transform.GetChild(0).GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;

        // Assigns numbers to plates.
        plate1.text = "1. : " + firstNum.ToString();
        plate2.text = "2. : " + secondNum.ToString();
        plate3.text = "3. : " + thirdNum.ToString();
        plate4.text = "4. : " + fourthNum.ToString();

        numStr = firstNum.ToString() + secondNum.ToString() + thirdNum.ToString() + fourthNum.ToString();

        handScanner.SetActive(false);
    }

    void Update()
    {
        //Debug.Log(numStr + " == " + TMP_IF.text);
        // If statement that checks if PIN is correct, if true then makes hand scanner visible.
        if (numStr == TMP_IF.text)
        {
            Debug.Log("Code has been found and entered, enabling hand scanner.");
            handScanner.SetActive(true);
        }
    }

    public void TextInput()
    {
        if (TMP_IF.text.Length <= 5)
        {
            TMP_IF.text += input;
        }
    }

    public void RemoveSymb()
    {
        TMP_IF.text = TMP_IF.text[..^1];
    }

}
