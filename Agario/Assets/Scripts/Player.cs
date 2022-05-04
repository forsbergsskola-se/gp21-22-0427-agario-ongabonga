using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public int score;
    float sizeManipulator;
    
    
    void ControlSize(){
        sizeManipulator = 1 + score * 0.1f;
        GetComponentInParent<Transform>().localScale = new Vector3(sizeManipulator, sizeManipulator, 1);
    }

    void Update(){
        //TODO: make this get called when score changes!
        if (Input.GetKeyDown(KeyCode.F)){
            ControlSize();
        }
    }
}



