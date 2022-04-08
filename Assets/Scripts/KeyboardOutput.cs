using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;

public class KeyboardOutput : MonoBehaviour
{
    public string ipAdr;
    private TextMeshPro ipKeyboardOutput;
    private GameObject ipEnter;
    private GameObject startButton;
    private int port;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("Start Button");
        startButton.SetActive(false);
        ipKeyboardOutput = GameObject.Find("KeyboardOutput").GetComponent<TextMeshPro>();
        ipKeyboardOutput.text = "Button pressed";
        port = ConnectionInfo.getPort();
        ipEnter = GameObject.Find("IP Enter");
    }

    private void Update()
    {
        if (ConnectionInfo.connectionEstablished)
        {
            ipEnter.SetActive(false);
            startButton.SetActive(true);
        }
    }

    public void OnButtonPress()
    {
        if (ipKeyboardOutput.text == "Keyboard not supported on this platform.")
        {
            //ConnectionInfo.setIpAddress(ConnectionInfo.GetLocalIPAddress());
            ConnectionInfo.setIpAddress(ipAdr);
        }
        else if (ipKeyboardOutput.text == "")
        {
            ConnectionInfo.setIpAddress(ipAdr);
        }
        else
        {
            ConnectionInfo.setIpAddress(ipKeyboardOutput.text);
        }

        Log.AddText("Ip Address: " + ConnectionInfo.getIpAddress());

        UIManager.instance.ConnectToServer();
    }
}
