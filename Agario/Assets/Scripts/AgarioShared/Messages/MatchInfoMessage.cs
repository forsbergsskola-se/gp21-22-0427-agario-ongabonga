using System;
using AgarioShared.AgarioShared.Model;
using AgarioShared.Networking;

namespace AgarioShared.Messages
{
    [Serializable]
    public class MatchInfoMessage : MessageBase
    {
        public MatchInfo matchInfo;
    }
}