using AgarioShared.AgarioShared.Model;
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
    PlayerInfo playerInfo;

    void Start()
    {
        scoreText = GameObject.FindWithTag("Score");
        gameOverCanvas.SetActive(false);
        playerInfo.name = name;
        playerInfo.ready = true;
    }


    public void ControlSize()
    {
        sizeManipulator = 1 + score * 0.1f;
        GetComponentInParent<Transform>().localScale = new Vector3(sizeManipulator, sizeManipulator, 1);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("im colliding");
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
        playerInfo.score = score;
        //playerInfo.position = new System.Numerics.Vector3(transform.position.x, transform.position.y, transform.position.z);
        scoreText.GetComponent<TextMeshProUGUI>().text = $"Score: {score}";
       // ServerConnection.Instance.AgarioClient.SendMessage(new PlayerInfoMessage{playerInfo = playerInfo});
    }

    void ActivateGameOverScreen()
    {
        gameOverCanvas.SetActive(true);
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        
    }
}



