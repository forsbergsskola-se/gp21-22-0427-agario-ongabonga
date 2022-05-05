using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    float sizeManipulator;
    Collider2D myCollider;
    GameObject scoreText;
    GameObject gameOverCanvas;

    void Start(){
        scoreText = GameObject.FindWithTag("Score");
        gameOverCanvas = GameObject.FindWithTag("gameOver");
        gameOverCanvas.SetActive(false);
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
            var otherScore = other.gameObject.GetComponent<Player>().score;
            score += otherScore;
            other.gameObject.GetComponent<Player>().score = 0;
        }
    }

    void Update(){
        scoreText.GetComponent<TextMeshProUGUI>().text = $"Score: {score}";

        if (Input.GetKeyDown(KeyCode.Q)){
            gameOverCanvas.SetActive(true);
        }
    }
}



