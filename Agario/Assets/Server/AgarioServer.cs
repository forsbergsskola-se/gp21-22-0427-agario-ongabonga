using System.Net;
using System.Net.Sockets;

public class AgarioServer
{
  static IPEndPoint EndPoint = new IPEndPoint(IPAddress.Loopback, 22222);
  TcpListener tcpListener = new TcpListener(EndPoint);
  void Main(){
    
    tcpListener.Start();
    
    //what the server does goes here
    
    
    //shutdown the server!
    tcpListener.Stop();
  }

  void PlayerPositions(){
    var tcpClient = tcpListener.AcceptTcpClient();
    
  }
  
}

