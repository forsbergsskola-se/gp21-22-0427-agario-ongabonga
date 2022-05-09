using System;
using System.Net;
using System.Net.Sockets;
using Messages;
using TMPro;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;

    void Awake(){
        
    }
    public void GameStart()
    {
        var client = new TcpClient();
        //TODO: Using loopback temporarily, will need server host to add later?
        client.Connect(IPAddress.Loopback, 1337);
        var connection = AgarioClient.Instance;
        connection.Init(client, playerNameInput.text);
        AgarioClient.Instance.MatchInfoMessageRecieved += OnMatchInfoMessageRecieved;
        //SceneManager.LoadScene("Agario");
    }

    void OnDestroy(){
        AgarioClient.Instance.MatchInfoMessageRecieved -= OnMatchInfoMessageRecieved;
    }

    void OnMatchInfoMessageRecieved(MatchInfoMessage obj){
        if (obj.matchInfo.started){
            SceneManager.LoadScene("Agario");
        }
    }
    
    //TODO: Make async for expanding playerbase beyond Onga and BOnga
    
}
