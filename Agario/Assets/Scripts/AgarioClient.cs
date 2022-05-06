using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Messages;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgarioClient : MonoBehaviour{
  public event Action<MatchInfoMessage> matchInfoMessageRecieved; 
  static AgarioClient _Instance;
  StreamWriter streamWriter;
  StreamReader streamReader;

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
    streamReader = new StreamReader(client.GetStream());
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
      string? json = this.streamReader.ReadLine();
      var matchInfo = JsonUtility.FromJson<MatchInfoMessage>(json);
      Debug.Log(json);
      matchInfoMessageRecieved?.Invoke(matchInfo);
    }
  }
}
