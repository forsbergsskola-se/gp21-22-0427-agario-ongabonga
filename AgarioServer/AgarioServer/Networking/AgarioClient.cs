using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using AgarioShared.AgarioShared.Messages;
using AgarioShared.AgarioShared.Model;


namespace AgarioServer.Networking;

    public class AgarioClient 
    {
        public event Action<MatchInfoMessage> MatchInfoMessageRecieved;
        private readonly PlayerInfo _playerInfo;
        private readonly AgarioMatch _match;
        StreamWriter streamWriter;

        //TODO: Replace void Init with this.
        public AgarioClient(TcpClient client, AgarioMatch match, PlayerInfo playerInfo)
        {
            _match = match;
            _playerInfo = playerInfo;
            this.Client = client;
            this.streamWriter = new StreamWriter(client.GetStream());
            new Thread(ReadPlayer).Start();
        }
        
        
        //TODO: Fix/replace with the AgarioClient() above
        public void Init(TcpClient client, string strongName)
        {
            Client = client;
            playerName = strongName;
            streamWriter = new StreamWriter(client.GetStream());
            new Thread(ReadPlayer).Start();
            SendMessage(new AgarioShared.AgarioShared.Messages.LogInMessage()
            {
                strongName = playerName
            });
        }

        public TcpClient Client { get; private set; }
        public string playerName{ get; private set; }

        public void SendMessage<T>(T message)
        {
            //TODO: Fix or remove this?
            //streamWriter.WriteLine(JsonUtility.ToJson(message));
            streamWriter.Flush();
        }

        void ReadPlayer()
        {
            var streamReader = new StreamReader(Client.GetStream());
            while (true)
            {
                string? json = streamReader.ReadLine();
                //TODO: Fix or remove this?
                // var matchInfo = JsonUtility.FromJson<MatchInfoMessage>(json);
                // matchInfo.matchInfo.started = true;
                // MatchInfoMessageRecieved?.Invoke(matchInfo);
            }
        }
    }

