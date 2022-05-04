using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NomNomSpawner : MonoBehaviour
{
    PlayArea area;
    [SerializeField] GameObject NomNomablesprefab;
    int nomNomablesCount;
    IEnumerator coroutine;
    bool hasSpawnedRecently;
    
    void Awake()
    {
        area = FindObjectOfType<PlayArea>();
    }

    void FixedUpdate()
    {
        if (!hasSpawnedRecently)
        {
            coroutine = SpawnNomNom(5.0f);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator SpawnNomNom(float waitTime)
    {
        if (nomNomablesCount < 20)
        {
            Instantiate(NomNomablesprefab, area.RandomSpawn(), quaternion.identity);
            nomNomablesCount++;
            hasSpawnedRecently = true;
            yield return new WaitForSeconds(waitTime);
            hasSpawnedRecently = false;
        }
    }
}
