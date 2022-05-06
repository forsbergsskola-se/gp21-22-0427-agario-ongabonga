using System.Net;
using System.Net.Sockets;

namespace AgarioServer;

public static class Program
{
    public static void Main()
    {
        var tcpListener = new TcpListener(IPAddress.Any, 1337);
        tcpListener.Start();

        Console.WriteLine("Listening on: " + tcpListener.LocalEndpoint);

        AgarioMatch match = null;

        while (true)
        {
            Console.WriteLine("Waiting for players to connect");
            var tcpClient = tcpListener.AcceptTcpClient();

            Console.WriteLine($"{tcpClient.Client.RemoteEndPoint} has achieved maximum connectitude, baby!");

            if (match == null)
            {
                Console.WriteLine("Onga here! Awaiting arrival of Bonga");
                match = new AgarioMatch();
                match.InitOnga(tcpClient);

            }
            else
            {
                Console.WriteLine("Onga here first now Bonga here 2. Time for OngaBonga");
                match.InitBonga(tcpClient);
                new Thread(match.Start).Start();
                match = null;
            }
        }
    }
}