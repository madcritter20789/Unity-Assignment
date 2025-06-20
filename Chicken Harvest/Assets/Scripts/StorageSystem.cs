using UnityEngine;

public class StorageSystem : MonoBehaviour
{
    public int eggStorageLimit = 100;
    public int popcornStorageLimit = 50;

    public bool CanStoreEggs(int count)
    {
        return GameManager.Instance.eggCount + count <= eggStorageLimit;
    }

    public bool CanStorePopcorn(int count)
    {
        return GameManager.Instance.popcornCount + count <= popcornStorageLimit;
    }
}