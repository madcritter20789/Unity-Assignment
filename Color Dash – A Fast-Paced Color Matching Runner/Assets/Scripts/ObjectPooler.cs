using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler Instance;

    public GameObject[] gatePrefabs;
    public int poolSize = 10;

    private List<GameObject>[] gatePools;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        gatePools = new List<GameObject>[gatePrefabs.Length];

        for (int i = 0; i < gatePrefabs.Length; i++)
        {
            gatePools[i] = new List<GameObject>();
            for (int j = 0; j < poolSize; j++)
            {
                GameObject obj = Instantiate(gatePrefabs[i]);
                obj.SetActive(false);
                gatePools[i].Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(int index)
    {
        foreach (GameObject obj in gatePools[index])
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        GameObject newObj = Instantiate(gatePrefabs[index]);
        gatePools[index].Add(newObj);
        return newObj;
    }
}
