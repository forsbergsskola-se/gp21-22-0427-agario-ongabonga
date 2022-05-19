using AgarioShared.AgarioShared.Model;
using AgarioShared.Assets.Scripts.AgarioShared.Messages;
using AgarioShared.Messages;
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
    PlayerInfo playerInfo = new PlayerInfo(); //TODO: why is this never assigned? ofc its empty?
    float playerX, playerY;
    PlayerPosition playerPosition;

    void Start()
    {
        ServerConnection.Instance.Connection.Subscribe<MatchInfoMessage>(OnMatchInfoMessageReceived);
        scoreText = GameObject.FindWithTag("Score");
        gameOverCanvas.SetActive(false);
        playerInfo.ready = true;
    }

    

    void OnMatchInfoMessageReceived(MatchInfoMessage obj){
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
        playerX = transform.position.x;
        playerY = transform.position.y;
        playerPosition = new PlayerPosition(playerX, playerY);
        var message = new PositionMessage();
        message.playerPosition = playerPosition;
        ServerConnection.Instance.Connection.SendMessage(message);
        scoreText.GetComponent<TextMeshProUGUI>().text = $"Score: {score}";
    }

    void ActivateGameOverScreen()
    {
        gameOverCanvas.SetActive(true);
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        
    }
}



