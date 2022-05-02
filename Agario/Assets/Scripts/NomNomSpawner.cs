using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NomNomSpawner : MonoBehaviour
{
    private PlayArea area;
    [SerializeField] private GameObject NomNomablesprefab;
    private int NomNomablesCount;
    private IEnumerator coroutine;
    private bool hasSpawnedRecently = false;
    
    void Awake()
    {
        area = FindObjectOfType<PlayArea>();
    }

    private void FixedUpdate()
    {
        if (!hasSpawnedRecently)
        {
            coroutine = SpawnNomNom(5.0f);
            StartCoroutine(coroutine);
           // hasSpawnedRecently = false;
        }
    }

    // private void FixedUpdate()
    // {
    //     if(NomNomablesCount < 50)
    //     {
    //         Invoke("SpawnNomNom", 5f);
    //     }
    // }

    private IEnumerator SpawnNomNom(float waitTime)
    {
        if (NomNomablesCount < 20)
        {
            Instantiate(NomNomablesprefab, area.RandomSpawn(), quaternion.identity);
            NomNomablesCount++;
            hasSpawnedRecently = true;
            yield return new WaitForSeconds(waitTime);
            hasSpawnedRecently = false;
        }
    }
}
