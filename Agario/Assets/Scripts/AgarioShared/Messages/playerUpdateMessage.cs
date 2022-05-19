using System;
using AgarioShared.AgarioShared.Model;
using AgarioShared.Networking;

namespace AgarioShared.Assets.Scripts.AgarioShared.Messages{
    [Serializable]
    public class playerUpdateMessage : MessageBase{
        public PlayerPosition playerPosition;
        public int score;

    }
}