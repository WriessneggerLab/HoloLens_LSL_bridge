using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class Log : MonoBehaviour
{
    private static string[] logString = new string[16];
    private static TMP_Text LogText;
    private static int inputCoutner = 1;

    private void Start()
    {
        LogText = GetComponent<TMP_Text>();
    }

    public static void AddText(string text)
    {
        if (inputCoutner < 16)
        {
            logString[inputCoutner] = System.DateTime.Now.ToString().Substring(11) + " - " + text + "\n";
            LogText.text += logString[inputCoutner];
            inputCoutner++;
        }
        else
        {
            LogText.text = "";
            for (int i = 0; i < inputCoutner-1; i++)
            {
                logString[i] = logString[i + 1];
                LogText.text += logString[i];
            }
            logString[inputCoutner-1] = System.DateTime.Now.ToString().Substring(11) + " - " + text + "\n";
            LogText.text += logString[inputCoutner-1];
            
        }
    }
}
