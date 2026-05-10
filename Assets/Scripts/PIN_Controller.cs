using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PIN_Controller : MonoBehaviour
{
    public TextMeshProUGUI TMP_IF;
    public string input;
    
    public void TextInput() {
        if (TMP_IF.text.Length <= 7)
        {
            TMP_IF.text += input;
        }
    }

    public void RemoveSymb()
    {
        TMP_IF.text = TMP_IF.text[..^1];
    }

}
