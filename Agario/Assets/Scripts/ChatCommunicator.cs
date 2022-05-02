using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;

public class ChatCommunicator : MonoBehaviour{
    TMP_InputField chatInput;
    [SerializeField] private GameObject errorPanel;
    [SerializeField] TMP_Text chatOutput;
    
    IPEndPoint serverEndpoint = new IPEndPoint(IPAddress.Loopback, 13337);
    static IPEndPoint clientEndpoint = new IPEndPoint(IPAddress.Loopback, 16666);
    UdpClient udpClient;
    void Start()
    {
        udpClient = new UdpClient(clientEndpoint);
        chatInput = FindObjectOfType<TMP_InputField>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            errorPanel.SetActive(true);
        }
    }

    public void SendChatMessage()
    {
        try
        {
            //TODO: Fix socketexception on multiple clicks/attempts/requests

            var msg = Encoding.ASCII.GetBytes(chatInput.text);
            udpClient.Send(msg, msg.Length, serverEndpoint);
            ReceiveMessage();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public void ReceiveMessage()
    {
        try
        {
            var response = udpClient.Receive(ref serverEndpoint);
            Debug.Log(Encoding.ASCII.GetString(response));
            chatOutput.text = Encoding.ASCII.GetString(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}
