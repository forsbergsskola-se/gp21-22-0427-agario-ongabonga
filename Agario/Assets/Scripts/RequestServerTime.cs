using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class RequestServerTime : MonoBehaviour
{
   
    public void SendRequest()
    {
        var clientEndpoint = new IPEndPoint(IPAddress.Loopback,1338);
        var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 1337);
      
        //Start a client on our end point
        var tcpClient = new TcpClient(clientEndpoint);
      
        //Connects to server's end point
        tcpClient.Connect(serverEndpoint);
      
        var stream = tcpClient.GetStream();
        Byte[] bytes = new Byte[100];
      
        stream.Read(bytes, 0, bytes.Length);
        var msg = Encoding.ASCII.GetString(bytes);
        
        Debug.Log("Simon says! Time & Date iz: "+msg);
      
        //Close client
        tcpClient.Close();
    }
}