using System;
using AgarioShared.Networking;

namespace AgarioShared.Messages
{
    [Serializable]
    public class LogInMessage : MessageBase
    {
        public string strongName;

    }
}