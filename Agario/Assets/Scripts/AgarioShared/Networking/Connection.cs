using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using AgarioShared.Assets.Scripts.AgarioShared.Interfaces;

namespace AgarioShared.Networking
{
  public class MessageBase{
    public string type;

    public MessageBase(){
      this.type = GetType().FullName;
    }
  }
  public class Connection 
  {
    readonly ILogger _logger;
    readonly IJson _json;
    readonly StreamWriter streamWriter;
    readonly Dictionary<Type, Delegate> listeners = new Dictionary<Type, Delegate>();
    TcpClient Client{ get; }
    public string playerName{ get; set; }


    public Connection(ILogger logger, IJson json, TcpClient client)
    {
      _logger = logger;
      _json = json;
      Client = client;
      streamWriter = new StreamWriter(client.GetStream());
      new Thread(ReceiveMessages).Start();
    }
    public void SendMessage<TMessage>(TMessage message) where TMessage : MessageBase{
      streamWriter.WriteLine(_json.Serialize(message));
      streamWriter.Flush();
      //TODO: need to send more messages at all times??
    }

    void ReceiveMessages(){
      var streamReader = new StreamReader(Client.GetStream());
      while (true){
        string? json = streamReader.ReadLine();
        if (json==null){
          continue;
        }
        var holder = _json.Deserialize<MessageBase>(json);
        if (holder == null){
          _logger.Log($"Invalid message received {json}");
          continue;
        }

        var type = AppDomain.CurrentDomain
          .GetAssemblies()
          .Select(assembly => assembly.GetType(holder.type))
          .SingleOrDefault(type => type != null);
        if (type == null){
          _logger.Log($"Unsupported message of type {holder.type} received.");
          continue;
        }
        var objectHolder = _json.Deserialize(json, type) as MessageBase;
        if (listeners.TryGetValue(type, out var listener)){
          listener.DynamicInvoke(objectHolder);
        }
      }
    }

    public void Subscribe<TMessage>(Action<TMessage> onMessageReceived) where TMessage : MessageBase{
      if (listeners.TryGetValue(typeof(TMessage), out  var del)){
        listeners[typeof(TMessage)] = Delegate.Combine(del, onMessageReceived);
      }
      else{
        listeners[typeof(TMessage)] = onMessageReceived;
      }
    }

    public void UnSubscribe<TMessage>(Action<TMessage> onMessageReceived) where TMessage : MessageBase{
      if (listeners.TryGetValue(typeof(TMessage), out var del)){
        listeners[typeof(TMessage)] = Delegate.Remove(del, onMessageReceived);
      }
    }
  }
}
