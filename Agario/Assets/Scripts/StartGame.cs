using System.Net;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] TMP_InputField playerNameInput;
    
    //TODO: Make async for expanding playerbase beyond Onga and the BOnga
    public void GameStart()
    {
        var client = new TcpClient();
        //TODO: Using loopback temporarily, will need server host to add later?
        client.Connect(IPAddress.Loopback, 1337);
        var connection = AgarioClient.Instance;
        connection.Init(client, playerNameInput.text);
        SceneManager.LoadScene("Agario");
    }
}