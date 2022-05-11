using System;

namespace Messages
{
    [Serializable]
    public class MatchInfoMessage
    {
        public MatchInfo matchInfo;
    }

    [Serializable]
    public class MatchInfo
    {
        public bool started;
        public PlayerInfo onga = new PlayerInfo();
        public PlayerInfo bonga = new PlayerInfo();
    }
    [Serializable]
    public class PlayerInfo
    {
        public bool ready;
        public string name;
        public int score;
    }
}