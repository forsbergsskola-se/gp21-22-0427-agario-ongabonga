using System;
using System.Collections;
using System.Collections.Generic;
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
      
      //Start a client on our end point - ?
      var tcpClient = new TcpClient(clientEndpoint);
      
      //Connects to server's end point - ?
      tcpClient.Connect(serverEndpoint);
      
      var stream = tcpClient.GetStream();
      Byte[] bytes = new Byte[100];
      
      var msg = stream.Read(bytes, 0, bytes.Length);
      Debug.Log("Simon says: "+Encoding.ASCII.GetString(bytes));
      
      //Close client
      tcpClient.Close();
   }
}
