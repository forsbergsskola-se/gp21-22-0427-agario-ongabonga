using System.Net;
using System.Net.Sockets;
using AgarioShared.Assets.Scripts.AgarioShared.Interfaces;
using AgarioShared.Messages;
using AgarioShared.Networking;
using UnityEngine;

public class ServerConnection
{
    static ServerConnection _instance;
    public Connection Connection;

    public static ServerConnection Instance{
        get{
            _instance ??= new ServerConnection();
            return _instance;
        }
    }

    public void Connect(string playerName){
        var client = new TcpClient();
        client.Connect(IPAddress.Loopback, 1337);
        Connection = new Connection(new UnityLogger(), new UnityJson(), client);
        Connection.Subscribe<MatchInfoMessage>(OnMessageReceived);
        Connection.playerName = playerName;
        Connection.SendMessage(new LogInMessage{
            strongName = playerName
        });
    }

    void OnMessageReceived(MatchInfoMessage matchInfo){
        Debug.Log(matchInfo.matchInfo.onga.name);
    }
}
