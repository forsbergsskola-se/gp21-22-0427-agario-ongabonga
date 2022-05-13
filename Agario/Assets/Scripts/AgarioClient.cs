using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Messages;
using UnityEngine;

public class AgarioClient 
{
  public event Action<MatchInfoMessage> MatchInfoMessageRecieved; 
  static AgarioClient _Instance;
  StreamWriter streamWriter;

  public static AgarioClient Instance
  {
    get
    {
      _Instance ??= new AgarioClient();
      return _Instance;
    }
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
    streamWriter.WriteLine(JsonUtility.ToJson(message));
    streamWriter.Flush();
  }

  void ReadPlayer(){
    var streamReader = new StreamReader(Client.GetStream());
    while (true){
      string? json = streamReader.ReadLine();
      var matchInfo = JsonUtility.FromJson<MatchInfoMessage>(json);
      matchInfo.matchInfo.started = true;
      ///TODO: should we have another event that is invoked repetedly
      MatchInfoMessageRecieved?.Invoke(matchInfo);
    }
  }
}
