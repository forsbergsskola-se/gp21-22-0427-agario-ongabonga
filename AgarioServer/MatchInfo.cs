using System.Numerics;

namespace AgarioServer;

public class MatchInfo
{
    public bool started;
    public PlayerInfo Onga = new ();
    public PlayerInfo Bonga = new ();
}

public class PlayerInfo
{
    public string name;
    public int score;
    public bool ready;
    public Vector3 position;
}