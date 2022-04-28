using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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

    public void SendRequest(){
        ConnectToServer();
    }

    async  Task ConnectToServer()
    {
        var clientEndpoint = new IPEndPoint(IPAddress.Loopback,4444);
        var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 1337);
      
        //Start a client on our end point
        var tcpClient = new TcpClient(clientEndpoint);
      
        //Connects to server's end point
        await tcpClient.ConnectAsync(serverEndpoint.Address, serverEndpoint.Port);
      
        var stream = tcpClient.GetStream();
        var buffer = new byte[100];
      
        stream.Read(buffer, 0, buffer.Length);
        var msg = Encoding.ASCII.GetString(buffer);
        
        Debug.Log($"Simon says! Time & Date iz: {msg}");
        timeOutput.text = $"Time & Date: {msg}";

        //Close client
        stream.Close();
        tcpClient.Close();
    }
    
    
}