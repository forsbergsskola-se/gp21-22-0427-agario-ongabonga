using System;

namespace AgarioShared.AgarioShared.Model{

    [Serializable]
    public class PlayerPosition{
        public float playerX, playerY;

        public PlayerPosition(float playerX, float playerY){
            this.playerX = playerX;
            this.playerY = playerY;
        }
    }
}