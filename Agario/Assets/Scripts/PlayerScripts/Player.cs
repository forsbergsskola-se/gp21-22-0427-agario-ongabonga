using AgarioShared.AgarioShared.Model;
using AgarioShared.Messages;
using Messages;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    float sizeManipulator;
    Collider2D myCollider;
    public GameObject scoreText;
    public GameObject gameOverCanvas;
    MatchInfo matchInfo;
    PlayerInfo playerInfo; //TODO: why is this never assigned? ofc its empty?
    Vector3 positionInfo;

    void Start()
    {
        ServerConnection.Instance.Connection.Subscribe<MatchInfoMessage>(OnMatchInfoMessage);
        scoreText = GameObject.FindWithTag("Score");
        gameOverCanvas.SetActive(false);
        playerInfo.ready = true;
    }

    void OnMatchInfoMessage(MatchInfoMessage obj){
        playerInfo = obj.matchInfo.onga;
    }


    public void ControlSize()
    {
        sizeManipulator = 1 + score * 0.1f;
        GetComponentInParent<Transform>().localScale = new Vector3(sizeManipulator, sizeManipulator, 1);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        myCollider = GetComponent<Collider2D>();
        if (myCollider.bounds.Contains(other.bounds.min) && myCollider.bounds.Contains(other.bounds.max)){
            var otherPlayer = other.gameObject.GetComponent<ServerPlayer>();
            score += otherPlayer.score;
            other.gameObject.GetComponent<ServerPlayer>().score = 0;
        }
        if (other.bounds.Contains(myCollider.bounds.min)&& other.bounds.Contains(myCollider.bounds.max))
        {
            ActivateGameOverScreen();
        }
    }

    void Update(){
        //TODO: send this to the server and let it interpretate
        playerInfo.score = score;
        positionInfo = transform.position;
        scoreText.GetComponent<TextMeshProUGUI>().text = $"Score: {score}";
    }

    void ActivateGameOverScreen()
    {
        gameOverCanvas.SetActive(true);
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        
    }
}



