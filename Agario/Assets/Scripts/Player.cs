using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    float sizeManipulator;
    private Collider2D myCollider;
    
    
    public void ControlSize()
    {
        sizeManipulator = 1 + score * 0.1f;
        GetComponentInParent<Transform>().localScale = new Vector3(sizeManipulator, sizeManipulator, 1);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        myCollider = GetComponent<Collider2D>();
        if (myCollider.bounds.Contains(other.bounds.min) && myCollider.bounds.Contains(other.bounds.max))
        {
            //TODO: NOM NOM. But first, LUNCH NOM NOM
            Debug.Log("Oh No, tiny player got eaten :O!");
        }
    }
}



