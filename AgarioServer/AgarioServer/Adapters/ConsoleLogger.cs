using AgarioShared.Assets.Scripts.AgarioShared.Interfaces;

namespace AgarioServer.Adapters;

public class ConsoleLogger : ILogger{
    public void Log(string message){
        Console.WriteLine(message);
    }
}