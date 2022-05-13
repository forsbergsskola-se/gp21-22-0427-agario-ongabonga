using AgarioShared.AgarioShared.Networking;
using AgarioShared.Assets.Scripts.AgarioShared.Interfaces;

public class ConnectionSingleton
{
    private static ConnectionSingleton _instance;

    public AgarioClient AgarioClient = new AgarioClient(new UnityLogger(), new UnityJson());

    public static ConnectionSingleton Instance
    {
        get
        {
            _instance ??= new ConnectionSingleton();
            return _instance;
        }
    }
}
