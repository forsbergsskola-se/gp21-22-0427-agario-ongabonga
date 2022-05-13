using System.Net;
using System.Net.Sockets;
using AgarioShared.AgarioShared.Messages;
using AgarioShared.AgarioShared.Networking;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AgarioShared
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField] TMP_InputField playerNameInput;
        bool _started;

        void Awake()
        {
            ConnectionSingleton.Instance.AgarioClient.MatchInfoMessageRecieved += OnMatchInfoMessageRecieved;
        }
        public void GameStart()
        {
            var client = new TcpClient();
            client.Connect(IPAddress.Loopback, 1337);
            var connection = ConnectionSingleton.Instance.AgarioClient;
            connection.Init(client, playerNameInput.text);
        }
        void Update()
        {
            if (_started)
            {
                SceneManager.LoadScene("Agario");
            }
        }

        void OnDestroy()
        {
            ConnectionSingleton.Instance.AgarioClient.MatchInfoMessageRecieved -= OnMatchInfoMessageRecieved;
        }

        void OnMatchInfoMessageRecieved(MatchInfoMessage obj)
        {
            _started = obj.matchInfo.started;
        }

    }
}

