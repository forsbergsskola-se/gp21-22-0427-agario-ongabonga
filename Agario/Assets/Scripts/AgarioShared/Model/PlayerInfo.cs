using System;
using UnityEngine;

namespace Model
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