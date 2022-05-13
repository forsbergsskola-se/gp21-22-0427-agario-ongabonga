using System;
using UnityEngine;

namespace AgarioShared.AgarioShared.Model
{
    [Serializable]
    public class PlayerInfo
    {
        public bool ready;
        public string name;
        public int score;
        public Vector3 position;
    }
}