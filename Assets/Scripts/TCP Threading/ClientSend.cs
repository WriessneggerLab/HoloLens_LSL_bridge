using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    #region Packets
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write("HoloLens");

            SendTCPData(_packet);
        }
    }

    public static void SendOutletLSL(string _msg)
    {
        using (Packet _packet = new Packet((int)ClientPackets.messageReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(_msg);

            SendTCPData(_packet);
        }
    }

    #endregion
}
