using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayArea : MonoBehaviour{
    int fieldX = 100;
    int fieldY = 100;
    
    public int[,] ClampPositions(int x,int y){
        var newX = math.clamp(x,0,fieldX);
        var newY = math.clamp(y,0,fieldY);
        var clampedPos = new int[newX, newY];
        return clampedPos;
    }

    public Vector3 RandomSpawn(){ //TODO: make sure 2 players doesnt spawn atop of each other
        var pos = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
        return pos;
    }
}
