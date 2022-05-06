using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Messages;
using UnityEngine;

public class AgarioClient : MonoBehaviour
{
  private static AgarioClient _Instance;
  private StreamWriter streamWriter;
  private StreamReader streamReader;

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
    this.Client = client;
    this.playerName = strongName;
    this.streamWriter = new StreamWriter(client.GetStream());
    this.streamReader = new StreamReader(client.GetStream());
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
