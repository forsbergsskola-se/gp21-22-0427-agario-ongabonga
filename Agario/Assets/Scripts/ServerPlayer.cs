using Messages;
using Model;
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
        AgarioClient.Instance.MatchInfoMessageRecieved += OnMatchInfoMessageRecieved;
    }

    void OnDestroy(){
        AgarioClient.Instance.MatchInfoMessageRecieved -= OnMatchInfoMessageRecieved;
    }

    
    //TODO: this is never called? its not being invoked currently?
    void OnMatchInfoMessageRecieved(MatchInfoMessage obj){
        playerInfo = obj.matchInfo.bonga;
        name = playerInfo.name;
        //TODO: this only supports one player, future should be with ID
    }

    void Update(){
        if (playerInfo.ready){
            score = playerInfo.score;
            transform.position = playerInfo.position;
        }
    }
    
}
