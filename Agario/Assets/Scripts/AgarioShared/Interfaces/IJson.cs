using System;

namespace AgarioShared.Assets.Scripts.AgarioShared.Interfaces
{
    public interface IJson
    {
        T Deserialize<T>(string json);
        object Deserialize(string json, Type type);
        string Serialize<T>(T data);
    }
}