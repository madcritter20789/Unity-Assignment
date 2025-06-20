using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Random = System.Random;

public class Hen : MonoBehaviour
{

    public float layTime;
    private float timer = 0f;

    public GameObject eggPrefab;
    public Transform eggSpawnPoint;

    private void Start()
    {
        layTime = UnityEngine.Random.Range(3.5f, 12.0f);
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= layTime)
        {
            SpawnEgg();
            timer = 0f;
        }
    }

    void SpawnEgg()
    {
        if (eggPrefab && eggSpawnPoint)
        {
            Instantiate(eggPrefab, eggSpawnPoint.position, Quaternion.identity);
        }
    }
}