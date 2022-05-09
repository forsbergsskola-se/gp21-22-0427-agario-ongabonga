using System;
using System.Collections;
using System.Collections.Generic;
using Messages;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour{
   [SerializeField] GameObject playerPrefab;
   PlayArea area;
   
   bool isAlreadySpawned;

   void Awake()
   {
      area = FindObjectOfType<PlayArea>();
   }

   void Update()
   {
      SpawnPlayer();
   }

   void SpawnPlayer()
   {
      if (Input.GetKey(KeyCode.Space) && !isAlreadySpawned)
      {
         Instantiate(playerPrefab, area.RandomSpawn(), quaternion.identity);
         isAlreadySpawned = true;
      }
   }
   
   
}
