using System;
using UnityEngine;

public class ConsumeNomNom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("hello lolololol");
        var player = col?.GetComponent<Player>();
        player.score++;
        FindObjectOfType<NomNomSpawner>().nomNomablesCount--;
        Destroy(gameObject);
    }
}
