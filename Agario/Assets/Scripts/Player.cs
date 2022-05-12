using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    float sizeManipulator;
    Collider2D myCollider;
    public GameObject scoreText;
    public GameObject gameOverCanvas;

    void Start()
    {
        scoreText = GameObject.FindWithTag("Score");
        gameOverCanvas.SetActive(false);  //TODO: the playerdummy does the deactivation for both players, so real player cant find
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
        //maybe instead compare radius and see if overlapping with radius??
        if (myCollider.bounds.Contains(other.bounds.min) && myCollider.bounds.Contains(other.bounds.max)){
            Debug.Log("nomnom");
            var otherPlayer = other.gameObject.GetComponent<Player>();
            score += otherPlayer.score;
            other.gameObject.GetComponent<Player>().score = 0;
        }
        else{
            Debug.Log(myCollider.bounds.size);
            Debug.Log(other.bounds.size);
        }
        if (other.bounds.Contains(myCollider.bounds.min)&& other.bounds.Contains(myCollider.bounds.max))
        {
            Debug.Log("wtf isnt this working");
            ActivateGameOverScreen();
        }
    }

    void Update()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = $"Score: {score}";
    }

    void ActivateGameOverScreen()
    {
        gameOverCanvas.SetActive(true);
    }
}



