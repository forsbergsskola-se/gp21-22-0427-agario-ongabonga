using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using AgarioShared.AgarioShared.Messages;
using AgarioShared.Assets.Scripts.AgarioShared.Interfaces;
using ILogger = AgarioShared.Assets.Scripts.AgarioShared.Interfaces.ILogger;

namespace AgarioShared.AgarioShared.Networking
{
  public class AgarioClient 
  {
    private readonly ILogger _logger;
    private readonly IJson _json;
    public event Action<MatchInfoMessage> MatchInfoMessageRecieved; 
    static AgarioClient _Instance;
    StreamWriter streamWriter;
    

    public AgarioClient(ILogger logger, IJson json)
    {
      _logger = logger;
      _json = json;
    }

    public void Init(TcpClient client, string strongName)
    {
      Client = client;
      playerName = strongName;
      streamWriter = new StreamWriter(client.GetStream());
      new Thread(ReadPlayer).Start();
      SendMessage(new LogInMessage
      {
        strongName = playerName
      });
    }

    public TcpClient Client { get; private set; }
    public string playerName{ get; private set; }

    public void SendMessage<T>(T message)
    {
      streamWriter.WriteLine(_json.Serialize(message));
      streamWriter.Flush();
    }

    void ReadPlayer()
    {
      var streamReader = new StreamReader(Client.GetStream());
      while (true)
      {
        string? json = streamReader.ReadLine();
        var matchInfo = _json.Deserialize<MatchInfoMessage>(json);
        matchInfo.matchInfo.started = true;
        MatchInfoMessageRecieved?.Invoke(matchInfo);
        _logger.Log(json);
      }
    }
  }
}
