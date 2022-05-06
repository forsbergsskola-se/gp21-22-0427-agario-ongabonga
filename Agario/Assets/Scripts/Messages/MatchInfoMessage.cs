namespace Messages{
    public class MatchInfoMessage{
        public MatchInfo matchInfo;
    }


    public class MatchInfo{
        public bool started;
        public PlayerInfo onga = new PlayerInfo();
        public PlayerInfo bonga = new PlayerInfo();
    }

    public class PlayerInfo{
        public bool ready;
        public string name;
        public int score;
    }
}