using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour{
   [SerializeField] GameObject playerPrefab;
   PlayArea area;
   
   bool isAlreadySpawned;

   void Awake(){
      area = FindObjectOfType<PlayArea>();
   }

   void Update(){
      SpawnPlayer();
   }

   void SpawnPlayer(){
      if (Input.GetKey(KeyCode.Space) && !isAlreadySpawned){
         Instantiate(playerPrefab, area.RandomSpawn(), quaternion.identity);
         isAlreadySpawned = true;
      }
   }
}
