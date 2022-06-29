using System;
using UnityEngine;

namespace AgarioShared.Assets.Scripts.AgarioShared.Interfaces{

    public class UnityJson : IJson{
        public T Deserialize<T>(string json){
            return JsonUtility.FromJson<T>(json);
        }

        public object Deserialize(string json, Type type){
            return JsonUtility.FromJson(json, type);
        }

        public string Serialize<T>(T data){
            return JsonUtility.ToJson(data);
        }
    }
}
