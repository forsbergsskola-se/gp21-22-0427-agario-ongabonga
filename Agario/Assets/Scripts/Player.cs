using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int score;
    float sizeManipulator;
    Collider2D myCollider;
    GameObject scoreText;

    void Start(){
        scoreText = GameObject.FindWithTag("Score");
    }


    public void ControlSize()
    {
        sizeManipulator = 1 + score * 0.1f;
        GetComponentInParent<Transform>().localScale = new Vector3(sizeManipulator, sizeManipulator, 1);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        myCollider = GetComponent<Collider2D>();
        if (myCollider.bounds.Contains(other.bounds.min) && myCollider.bounds.Contains(other.bounds.max))
        {
            //TODO: NOM NOM. But first, LUNCH NOM NOM
            Debug.Log("Oh No, tiny player got eaten :O!");
        }
    }

    void Update(){
        scoreText.GetComponent<TextMeshProUGUI>().text = $"Score: {score}";
    }
}



