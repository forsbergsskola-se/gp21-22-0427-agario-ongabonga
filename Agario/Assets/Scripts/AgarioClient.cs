using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Messages;
using UnityEngine;

public class AgarioClient : MonoBehaviour
{
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
}
