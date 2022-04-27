using System.Net;
using System.Net.Sockets;

namespace OngaBonga
{
    public class DumDum
    {
        static void Main()
        {
            TcpListener server = null;
            try
            {
                //Set TcpListener to port Elite, local address to X
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                //TcpListener server = new TcpListener(port); - alternative
                server = new TcpListener(localAddr, port);

                //Start listening for client requests
                server.Start();

                //Buffer for reading data
                Byte[] bytes = new byte[256];
                String data = null;

                //Enter the listening loop
                while (true)
                {
                    Console.Write("Waiting for a connection...");

                    //Perform a blocking call to accept requests
                    // server.AcceptSocket() - potential alternative
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Houston, we have a connection!");

                    data = null;

                    //Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    //Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        //Translate data bytes to ASCII string
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        //Process the data sent by the client
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        //Send back a response
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    //Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Socket Exception: {0}", e);
            }
            finally
            {
                //Stop listening for new clients
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}

