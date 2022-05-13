using System;
using System.Collections;
using System.Collections.Generic;
using AgarioShared.AgarioShared.Messages;
using AgarioShared.AgarioShared.Model;
using AgarioShared.AgarioShared.Networking;
using UnityEngine;

public class ServerPlayer : MonoBehaviour{
    float sizeManipulator;
    public int score;
    string name;
    PlayerInfo playerInfo;

    public void ControlSize()
    {
        sizeManipulator = 1 + score * 0.1f;
        GetComponentInParent<Transform>().localScale = new Vector3(sizeManipulator, sizeManipulator, 1);
    }

    void OnTriggerEnter2D(Collider2D col){
        ControlSize();
    }
    void Awake()
    {
        ConnectionSingleton.Instance.AgarioClient.MatchInfoMessageRecieved += OnMatchInfoMessageRecieved;
    }

    void OnDestroy(){
        ConnectionSingleton.Instance.AgarioClient.MatchInfoMessageRecieved -= OnMatchInfoMessageRecieved;
    }

    void OnMatchInfoMessageRecieved(MatchInfoMessage obj){
        playerInfo = obj.matchInfo.bonga;
        name = playerInfo.name;
        //TODO: this only supports one player, future should be with ID
    }

    void Update(){
        if (playerInfo.ready){
            score = playerInfo.score;
        }
    }
}
