using System;
using AgarioShared.AgarioShared.Model;
using AgarioShared.Networking;


namespace Messages
{
    [Serializable]
    public class PlayerInfoMessage : MessageBase
    {
        public PlayerInfo playerInfo;
    }
}