using AgarioShared.AgarioShared.Model;
using AgarioShared.Assets.Scripts.AgarioShared.Messages;
using AgarioShared.Messages;
using UnityEngine;

public class ServerPlayer : MonoBehaviour{
    float sizeManipulator;
    public int score;
    string name;
    PlayerInfo playerInfo = new PlayerInfo();
    PlayerPosition playerPos = new PlayerPosition(0,0);

    void Start(){
        ServerConnection.Instance.Connection.Subscribe<MatchInfoMessage>(OnMatchInfoMessage);
        ServerConnection.Instance.Connection.Subscribe<playerUpdateMessage>(OnPositionMessageReceived);
    }

    void OnPositionMessageReceived(playerUpdateMessage obj){
        playerPos = obj.playerPosition;
    }

    void OnMatchInfoMessage(MatchInfoMessage obj){
        playerInfo = obj.matchInfo.bonga;
    }

    public void ControlSize()
    {
        sizeManipulator = 1 + score * 0.1f;
        GetComponentInParent<Transform>().localScale = new Vector3(sizeManipulator, sizeManipulator, 1);
    }

    void OnTriggerEnter2D(Collider2D col){
        ControlSize();
    }
    void Update(){
        if (playerInfo.ready){
            score = playerInfo.score;
        }
        transform.position = new Vector3(playerPos.playerX, playerPos.playerY);
    }
}
