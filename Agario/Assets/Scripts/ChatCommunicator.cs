using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ChatCommunicator : MonoBehaviour
{
    private TextMeshProUGUI chatOutput;
    private void Start()
    {
        chatOutput = FindObjectOfType<TextMeshProUGUI>();
    }
    
    public void SendMessageRequest()
    {
        //TODO: Fix socketexception on multiple clicks/attempts/requests
        
        var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 13337);
        var clientEndpoint = new IPEndPoint(IPAddress.Loopback, 666);

        var udpClient = new UdpClient(clientEndpoint);

        var msg = Encoding.ASCII.GetBytes(chatOutput.text);
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
