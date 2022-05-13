using System;
using System.Numerics;

namespace Model
{
    [Serializable]
    public class MatchInfo
    {
        public bool started;
        public PlayerInfo onga = new PlayerInfo();
        public PlayerInfo bonga = new PlayerInfo();
        public Vector3 position;
    }
    
}