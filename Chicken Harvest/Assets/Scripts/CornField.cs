using UnityEngine;

public class CornField : MonoBehaviour
{
    public float growTime = 8f;
    private float timer = 0f;
    private bool ready = false;

    public GameObject cornPrefab;
    public Transform cornSpawnPoint;

    void Update()
    {
        if (!ready)
        {
            timer += Time.deltaTime;
            if (timer >= growTime)
            {
                ready = true;
                SpawnCorn();
            }
        }
    }

    void SpawnCorn()
    {
        if (cornPrefab && cornSpawnPoint)
        {
            Instantiate(cornPrefab, cornSpawnPoint.position, Quaternion.identity);
            ready = false;
            timer = 0f;
        }
    }
}