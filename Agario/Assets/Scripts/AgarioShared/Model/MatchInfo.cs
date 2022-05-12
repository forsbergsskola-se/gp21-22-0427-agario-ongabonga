using System;

namespace Model
{
    [Serializable]
    public class MatchInfo
    {
        public bool started;
        public PlayerInfo onga = new PlayerInfo();
        public PlayerInfo bonga = new PlayerInfo();
    }
    
}