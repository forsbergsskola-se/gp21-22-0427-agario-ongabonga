using System;
using AgarioShared.AgarioShared.Model;
using AgarioShared.Messages;
using UnityEngine;

public class ServerPlayer : MonoBehaviour{
    float sizeManipulator;
    public int score;
    string name;
    PlayerInfo playerInfo;
    MatchInfo matchInfo = new MatchInfo();

    void Start(){
        ServerConnection.Instance.Connection.Subscribe<MatchInfoMessage>(OnMatchInfoMessage);
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
    }
}
