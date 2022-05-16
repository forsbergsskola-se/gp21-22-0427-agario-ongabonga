using UnityEngine;
using ILogger = AgarioShared.Assets.Scripts.AgarioShared.Interfaces.ILogger;

public class UnityLogger: ILogger
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }
    }
