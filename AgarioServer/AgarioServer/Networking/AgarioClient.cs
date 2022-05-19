using System.Net.Sockets;
using AgarioServer.Adapters;
using AgarioShared.AgarioShared.Model;
using AgarioShared.Assets.Scripts.AgarioShared.Messages;
using AgarioShared.Messages;
using AgarioShared.Networking;


namespace AgarioServer.Networking;

    public class AgarioClient 
    {
        readonly PlayerInfo _playerInfo;
        readonly AgarioMatch _match;
        public float posX, posY;
        public Connection Connection{ get; }
        
        public AgarioClient(TcpClient client, AgarioMatch match, PlayerInfo playerInfo){
            Connection = new Connection(new ConsoleLogger(), new ConsoleJson(), client);
            _match = match;
            _playerInfo = playerInfo;
            Connection.Subscribe<LogInMessage>(OnMessageRecieved);
            Connection.Subscribe<PositionMessage>(OnPositionRecieved);
        }

        void OnPositionRecieved(PositionMessage obj){
            posX = obj.playerPosition.playerX;
            posY = obj.playerPosition.playerY;
            _match.DistributePlayerPositions();
        }

        void OnMessageRecieved(LogInMessage logInMessage){
            Console.WriteLine($"Player {logInMessage.strongName} logged in!");
            Connection.playerName = logInMessage.strongName;
            _playerInfo.name = logInMessage.strongName;
            _playerInfo.ready = true;
            _match.DistributeMatchInfo();
            
        }
    }



