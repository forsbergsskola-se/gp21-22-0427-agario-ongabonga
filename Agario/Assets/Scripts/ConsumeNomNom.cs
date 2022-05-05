using System;
using UnityEngine;

public class ConsumeNomNom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        var player = col?.GetComponent<Player>();
        player.score++;
        FindObjectOfType<NomNomSpawner>().nomNomablesCount--;
        player.ControlSize();
        Destroy(gameObject);
    }
}
