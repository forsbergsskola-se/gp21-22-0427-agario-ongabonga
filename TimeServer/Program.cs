using System.Net;
using System.Net.Sockets;
using System.Text;
 
namespace OngaBonga
{
    public class DumDum
    {
        static async Task Main() //JD - 192.168.1.188
        {
            //TcpListener server = new TcpListener(port); - obsolete
                var tcpListener = new TcpListener(IPAddress.Loopback, 1337);
                

                //Enter the listening loop
                while (true)
                {
                    //Start listening for client requests
                    tcpListener.Start();
                    Console.WriteLine("Waiting for a connection...");
                    
                    //Perform a blocking call to accept requests
                    var client = await tcpListener.AcceptTcpClientAsync();
                    Console.WriteLine("Houston, we have a connection!");

                    var msg = DateTime.Now.ToString();
                    //Get a stream object for reading and writing
                    var stream = client.GetStream();
                    
                    //var streamReader = new StreamReader(stream);
                    stream.Write(Encoding.ASCII.GetBytes(msg));
                    Console.WriteLine(msg);
                    
                    //Shutdown and end connection
                    stream.Close();
                    client.Close();
                    //Stop listening for new clients
                    //server.Stop();
                }
        }
    }
}

