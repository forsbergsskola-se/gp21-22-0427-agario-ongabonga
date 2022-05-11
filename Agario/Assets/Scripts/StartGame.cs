using System.Net;
using System.Net.Sockets;
using Messages;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;
    bool _started;

    void Awake(){
        AgarioClient.Instance.MatchInfoMessageRecieved += OnMatchInfoMessageRecieved;
    }
    public void GameStart()
    {
        var client = new TcpClient();
        //TODO: Using loopback temporarily, will need server host to add later?
        client.Connect(IPAddress.Loopback, 1337);
        var connection = AgarioClient.Instance;
        connection.Init(client, playerNameInput.text);
    }
    void Update()
    {
        if (_started){
            SceneManager.LoadScene("Agario");
        }
    }

    void OnDestroy(){
        AgarioClient.Instance.MatchInfoMessageRecieved -= OnMatchInfoMessageRecieved;
    }

    void OnMatchInfoMessageRecieved(MatchInfoMessage obj){
        _started = obj.matchInfo.started;
    }

    //TODO: Make async for expanding playerbase beyond Onga and BOnga
    
}
