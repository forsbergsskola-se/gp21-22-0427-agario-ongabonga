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
        var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 13337);
        var clientEndpoint = new IPEndPoint(IPAddress.Loopback, 66669);

        var udpClient = new UdpClient(clientEndpoint);

        var msg = Encoding.ASCII.GetBytes(chatOutput.text);
        udpClient.Send(msg, msg.Length, serverEndpoint);
    }
}
