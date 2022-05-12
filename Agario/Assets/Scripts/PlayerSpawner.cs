using System;
using Messages;
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
         Instantiate(playerPrefab, area.RandomSpawn(), quaternion.identity);
         isAlreadySpawned = true;
      }
   }
}
