using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewBehaviourScript : MonoBehaviour{
    int fieldX = 100;
    int fieldY = 100;
    
    public int[,] ClampPositions(int x,int y){
        var newX = math.clamp(x,0,100);
        var newY = math.clamp(y,0,100);
        var clampedPos = new int[newX, newY];
        return clampedPos;
    }

    public int[,] RandomSpawn(){ //TODO: make sure 2 players doesnt spawn atop of each other
        var pos = new int [
            Random.Range(0, 100)
            ,Random.Range(0, 100)] ;
        return pos;
    }
}
