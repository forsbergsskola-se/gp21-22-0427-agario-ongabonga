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
        var buffer = new byte[100];
        var allMessages = "";
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
                
                //receive and validate the message
                var msg = Encoding.ASCII.GetString(response);
                if (msg.Length <= 20 && !msg.Contains(' '))
                {
                    //do the thing with the stuff in the something
                    Console.Write($"Packet received from: {clientEndpoint} saying: {msg}");
                    allMessages = $"{allMessages} {msg}";
                    allMessages = allMessages.Trim();
                    buffer = Encoding.ASCII.GetBytes(allMessages);
                }
                else
                {
                    //- send to asshat who doesn't get word limitations back. We pity dat fool
                    Console.Write($"You invalid, fool! It's 20 character max and just the one word, which {msg} ain't");
                }
                //Send stuff back, close shit up
                server.Send(buffer, buffer.Length, clientEndpoint);
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
