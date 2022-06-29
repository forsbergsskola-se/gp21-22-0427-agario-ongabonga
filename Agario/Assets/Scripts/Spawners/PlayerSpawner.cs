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
      //TODO: this has not been instantiated before the last matchinfomessage has been sent.
      ServerConnection.Instance.Connection.Subscribe<MatchInfoMessage>(OnMessageRecieved);
   }

   void OnMessageRecieved(MatchInfoMessage obj){
      _matchInfo = obj.matchInfo;
   }

   void Update(){
      if (_matchInfo.started && !isAlreadySpawned){
         Instantiate(playerPrefab, area.RandomSpawn(), quaternion.identity);
         isAlreadySpawned = true;
      }
      else if (isAlreadySpawned && !isAlreadySpawned2){
         Instantiate(serverPlayerPrefab, area.RandomSpawn(), quaternion.identity);
         isAlreadySpawned2 = true;
      }

      if (Input.GetKeyDown(KeyCode.A)){
         var msg = new MatchInfoMessage{
            matchInfo = _matchInfo
         };
         ServerConnection.Instance.Connection.SendMessage(msg);
      }
   }
}
