using System.Net.Sockets;
using AgarioServer.Adapters;
using AgarioShared.AgarioShared.Model;
using AgarioShared.Messages;
using AgarioShared.Networking;


namespace AgarioServer.Networking;

    public class AgarioClient 
    {
        private readonly PlayerInfo _playerInfo;
        private readonly AgarioMatch _match;
        public Connection Connection{ get; }
        
        public AgarioClient(TcpClient client, AgarioMatch match, PlayerInfo playerInfo){
            Connection = new Connection(new ConsoleLogger(), new ConsoleJson(), client);
            _match = match;
            _playerInfo = playerInfo;
            Connection.Subscribe<LogInMessage>(OnMessageRecieved);
        }

        void OnMessageRecieved(LogInMessage logInMessage){
            Console.WriteLine($"Player {logInMessage.strongName} logged in!");
            Connection.playerName = logInMessage.strongName;
            _playerInfo.name = logInMessage.strongName;
            _playerInfo.ready = true;
            _match.DistributeMatchInfo();
        }
    }



