using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomNomSpawner : MonoBehaviour
{
    private PlayArea area;
    [SerializeField] private GameObject NomNomablesprefab;
    private int NomNomablesCount;
    
    void Awake()
    {
        area = FindObjectOfType<PlayArea>();
    }
    private void FixedUpdate()
    {
        while (NomNomablesCount < 50)
        {
            Invoke("SpawnNomNom", 3f);
        }
    }

    void SpawnNomNom()
    {
        Instantiate(NomNomablesprefab, area.RandomSpawn(), Quaternion.identity);
        NomNomablesCount++;
    }
}
