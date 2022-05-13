namespace AgarioServer;

public class MatchInfo
{
    public bool started;
    public PlayerInfo Onga = new ();
    public PlayerInfo Bonga = new ();
}

public class PlayerInfo
{
    //TODO: add player vector3 position to the playerInfo? so server knows where players are
    public string name;
    public int score;
    public bool ready;
}