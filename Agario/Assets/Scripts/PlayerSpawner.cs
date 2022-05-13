using System;
using Messages;
using Model;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour{
   [SerializeField] GameObject playerPrefab;
   PlayArea area;
   MatchInfo _matchInfo = new MatchInfo();
   
   bool isAlreadySpawned;

   void Awake()
   {
      area = FindObjectOfType<PlayArea>();
      AgarioClient.Instance.MatchInfoMessageRecieved += OnMatchInfoMessageRecieved;
   }

   void OnMatchInfoMessageRecieved(MatchInfoMessage obj){
      _matchInfo = obj.matchInfo;
   }

   void Update(){
      if (_matchInfo.started && !isAlreadySpawned){
         //TODO: make this spawn an instance of the server player not only local player! more connections means more players!
         
         //TODO: there should be a difference between the client-player and other players spawned.
         Instantiate(playerPrefab, area.RandomSpawn(), quaternion.identity);
         isAlreadySpawned = true;
      }
   }
}
