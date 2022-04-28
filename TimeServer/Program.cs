﻿using System.Net;
using System.Net.Sockets;
using System.Text;
 
namespace OngaBonga
{
    public class DumDum
    {
        static void Main() //JD - 192.168.1.188
        {
            //Set TcpListener to port Elite, local address to X
                var port = 1337;
                var localAddr = IPAddress.Loopback;

                //TcpListener server = new TcpListener(port); - obsolete
                var server = new TcpListener(localAddr, port);
                

                //Enter the listening loop
                while (true)
                {
                    //Start listening for client requests
                    server.Start();
                    Console.WriteLine("Waiting for a connection...");
                    
                    //Perform a blocking call to accept requests
                    var client = server.AcceptTcpClient();
                    Console.WriteLine("Houston, we have a connection!");

                    var msg = DateTime.Now.ToString();
                    //Get a stream object for reading and writing
                    var stream = client.GetStream();
                    
                    stream.Write(Encoding.ASCII.GetBytes(msg));
                    Console.WriteLine(msg);
                    
                    //Shutdown and end connection
                    stream.Close();
                    client.Close();
                    //Stop listening for new clients
                    server.Stop();
                }
        }
    }
}

