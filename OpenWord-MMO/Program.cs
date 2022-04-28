using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public static class Program 
{
    //This is Marc's Sample code for UDP Server, to be worked on tomorrow
    static void Main(string[] arguments) 
    {
        var serverEndpoint = new IPEndPoint(IPAddress.Loopback, 13337);
		
        // We open the Socket, so we can receive Packets
        var server = new UdpClient(serverEndpoint);
        try
        {
            while (true) 
            {
                // This struct will contain the info of the sender
                // After calling Receive
                IPEndPoint clientEndpoint = default;
                // Here, we receive a message from some client
                // A ref parameter means, that this function
                // can change the struct from within the function
                var response = server.Receive(ref clientEndpoint);
                Console.WriteLine($"Packet received from: {clientEndpoint} saying: {Encoding.ASCII.GetString(response)}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("Ruh-rohw");
            Console.WriteLine("Since you will never see this, here's my card's cvc: ");
        }
        
    }
}
