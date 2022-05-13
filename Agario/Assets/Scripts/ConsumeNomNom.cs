using UnityEngine;

public class ConsumeNomNom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        //TODO: this only increase local score not the server score
        var player = col?.GetComponent<Player>();
        player.score++;
        FindObjectOfType<NomNomSpawner>().nomNomablesCount--;
        player.ControlSize();
        Destroy(gameObject);
    }
    
}
