using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequestServerTime : MonoBehaviour
{
    private TextMeshProUGUI timeOutput;

    private void Start()
    {
        timeOutput = FindObjectOfType<TextMeshProUGUI>();
    }

    public void SendRequest()
    {
        var clientEndpoint = new IPEndPoint(IPAddress.Loopback,1338);
        var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 1337);
      
        //Start a client on our end point
        var tcpClient = new TcpClient(clientEndpoint);
      
        //Connects to server's end point
        tcpClient.Connect(serverEndpoint);
      
        var stream = tcpClient.GetStream();
        var bytes = new byte[100];
      
        stream.Read(bytes, 0, bytes.Length);
        var msg = Encoding.ASCII.GetString(bytes);
        
        Debug.Log($"Simon says! Time & Date iz: {msg}");
        timeOutput.text = $"Time & Date: {msg}";

        //Close client
        stream.Close();
        tcpClient.Close();
    }
    
    
}