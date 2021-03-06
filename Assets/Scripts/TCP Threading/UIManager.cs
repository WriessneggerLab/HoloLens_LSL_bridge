using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Log.AddText("Instance already exists, destroying object");
            Destroy(this);
        }
    }

    public void ConnectToServer()
    {
        Client.instance.ConnectToServer();
    }
}
