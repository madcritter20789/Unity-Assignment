using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawner : MonoBehaviour
{

    public float spawnInterval = 1.5f;
    private float timer;

    private float speed = 5f;
    public float speedIncreaseRate = 0.05f;

    // Update is called once per frame


    private void Update()
    {
        timer += Time.deltaTime;
        speed += speedIncreaseRate * Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0;
            SpawnGate();
        }
    }

    void SpawnGate()
    {
        int randomIndex = Random.Range(0, 3); // 0=Red, 1=Green, 2=Blue
        GameObject gate = ObjectPooler.Instance.GetPooledObject(randomIndex);
        gate.transform.position = transform.position;
        gate.SetActive(true);
        gate.GetComponent<Gate>().Initialize((PlayerColor)randomIndex, speed);
    }
}
