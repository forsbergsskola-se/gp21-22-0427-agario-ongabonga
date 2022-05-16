using AgarioShared.AgarioShared.Model;
using AgarioShared.Messages;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour{
   [SerializeField] GameObject playerPrefab;
   [SerializeField] GameObject serverPlayerPrefab;
   PlayArea area;
   MatchInfo _matchInfo = new MatchInfo();

   bool isAlreadySpawned;
   bool isAlreadySpawned2;

   void Awake()
   {
      area = FindObjectOfType<PlayArea>();
      ServerConnection.Instance.Connection.Subscribe<MatchInfoMessage>(OnMessageRecieved);
   }

   void OnMessageRecieved(MatchInfoMessage obj){
      _matchInfo = obj.matchInfo;
   }

   void Update(){
      if (_matchInfo.started && !isAlreadySpawned){
         //TODO: make this spawn an instance of the server player not only local player! more connections means more players!
         Instantiate(playerPrefab, area.RandomSpawn(), quaternion.identity);
         isAlreadySpawned = true;
      }
      //TODO: make sure it spawns a player for each player
      else if (isAlreadySpawned && !isAlreadySpawned2){
         Instantiate(serverPlayerPrefab, area.RandomSpawn(), quaternion.identity);
         isAlreadySpawned2 = true;
      }
   }
}
