using System.Net.Sockets;
using System.Text.Json;
using AgarioServer.Messages;

namespace AgarioServer;

public class Connection
{
    readonly AgarioMatch _match;
    readonly PlayerInfo _playerInfo;
    readonly StreamWriter _streamWriter;
    readonly JsonSerializerOptions options = new()
    {
        IncludeFields = true
    };
    
    TcpClient Client{ get; }

    public Connection(TcpClient client, AgarioMatch match, PlayerInfo playerInfo)
    {
        _match = match;
        _playerInfo = playerInfo;
        Client = client;
        _streamWriter = new StreamWriter(client.GetStream());
        new Thread(ReadPlayer).Start();
    }

    public void SendMessage<T>(T message)
    {
        _streamWriter.WriteLine(JsonSerializer.Serialize(message,options));
        _streamWriter.Flush();
    }
    
    public class Message
    {
        public string name;
    }
    
    public class Message<T> : Message
    {
        public T value;
    }

    void ReadPlayer(){
        var streamReader = new StreamReader(Client.GetStream());
        var options = new JsonSerializerOptions()
        {
            IncludeFields = true
        };
        while (true){
            string? json = streamReader.ReadLine();
            if (_playerInfo.ready)
            {
                //do some mechanic here perhaps??
            }
            else
            { 
                //if the player isn't ready we expect it to login instead!
                var loginMessage = JsonSerializer.Deserialize<LoginMessage>(json, options);
                Console.WriteLine($"Player {loginMessage.strongName} logged in!");
                _playerInfo.name = loginMessage.strongName;
                _playerInfo.ready = true;
            }
            _match.DistributeMatchInfo();
        }
    }
}