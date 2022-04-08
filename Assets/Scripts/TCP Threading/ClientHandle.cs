using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        ConnectionInfo.connectionEstablished = true;

        Log.AddText($"Message from Server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();
    }
}
