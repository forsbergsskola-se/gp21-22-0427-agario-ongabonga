using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;

public class ChatCommunicator : MonoBehaviour{
    TMP_InputField chatInput;
    TextMeshProUGUI chatOutput;
    private void Start()
    {
        chatInput = FindObjectOfType<TMP_InputField>();
    }
    
    public void SendChatMessage()
    {
        //TODO: Fix socketexception on multiple clicks/attempts/requests
        
        var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 13337);
        var clientEndpoint = new IPEndPoint(IPAddress.Loopback, 666);

        var udpClient = new UdpClient(clientEndpoint);

        var msg = Encoding.ASCII.GetBytes(chatInput.text);
        udpClient.Send(msg, msg.Length, serverEndpoint);
        
    }

    public void ReceiveMessage()
    {
        var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 13337);
        var clientEndpoint = new IPEndPoint(IPAddress.Loopback, 666);
        var udpClient = new UdpClient(clientEndpoint);
        var response = udpClient.Receive(ref serverEndpoint);
        chatOutput.text = Encoding.ASCII.GetString(response);
    }
}
