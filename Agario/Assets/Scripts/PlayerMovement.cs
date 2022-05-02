using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
   Vector3 mousePosition;
   float moveSpeed = 0.1f;
   
   void FixedUpdate(){
      mousePosition = Input.mousePosition;
      mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
      transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
   }
}
