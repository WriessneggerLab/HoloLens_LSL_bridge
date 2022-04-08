using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using static System.Exception;

public class ConnectionInfo : MonoBehaviour
{
    private static string ipAddress;
    private static int port = 10000;
    public static bool connectionEstablished = false;

    public static void setIpAddress(string IP)
    {
        ipAddress = IP;
    }

    public static string getIpAddress()
    {
        return ipAddress;
    }

    public static int getPort()
    {
        return port;
    }

    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        return ("no ip found");
    }
}
