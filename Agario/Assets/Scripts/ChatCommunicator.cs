using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;

public class ChatCommunicator : MonoBehaviour{
    TMP_InputField chatInput;
    TMP_Text chatOutput;
    
    IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 13337);
    static IPEndPoint clientEndpoint = new IPEndPoint(IPAddress.Loopback, 16666);
    UdpClient udpClient;
    private void Start()
    {
        udpClient = new UdpClient(clientEndpoint);
        chatInput = FindObjectOfType<TMP_InputField>();
        chatOutput = FindObjectOfType<TMP_Text>();
    }
    
    public void SendChatMessage()
    {
        //TODO: Fix socketexception on multiple clicks/attempts/requests

        var msg = Encoding.ASCII.GetBytes(chatInput.text);
        udpClient.Send(msg, msg.Length, serverEndpoint);
        ReceiveMessage();
    }

    public void ReceiveMessage()
    {   
        var response = udpClient.Receive(ref serverEndpoint);
        chatOutput.text = Encoding.ASCII.GetString(response);
    }
}
