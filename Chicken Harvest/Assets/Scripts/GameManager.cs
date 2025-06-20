using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int money = 0;
    public int eggCount = 0;
    public int popcornCount = 0;

    public int maxHens = 50;
    public int maxPopcornUnits = 50;

    public int henCost = 50;
    public int workerCost = 100;
    public int popcornMachineCost = 150;

    public GameObject henPrefab;
    public GameObject popcornMachinePrefab;
    public GameObject workerPrefab;
    public Transform henParent;
    public Transform popcornParent;
    public Transform workerParent;

    private int currentHenCount = 5;
    private int currentPopcornCount = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < currentHenCount; i++)
            SpawnHenStart();

        UIManager.Instance.UpdateUI(money, eggCount, popcornCount);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        UIManager.Instance.UpdateMoney(money);
    }

    public void SpendMoney(int amount)
    {
        money -= amount;
        UIManager.Instance.UpdateMoney(money);
    }

    public void AddEggs(int count)
    {
        eggCount += count;
        UIManager.Instance.UpdateEggs(eggCount);
    }

    public void SellEggs(int count)
    {
        if (eggCount >= count)
        {
            eggCount -= count;
            AddMoney(count * 5);
            UIManager.Instance.UpdateEggs(eggCount);
        }
    }

    public bool popcornUnlocked
    {
        get { return currentPopcornCount > 0; }
    }

    public void AddPopcorn(int count)
    {
        popcornCount += count;
        UIManager.Instance.UpdatePopcorn(popcornCount);
    }

    public void SellPopcorn(int count)
    {
        if (popcornCount >= count)
        {
            popcornCount -= count;
            AddMoney(count * 10);
            UIManager.Instance.UpdatePopcorn(popcornCount);
        }
    }

    public void SpawnHen()
    {
        if (currentHenCount < maxHens && money >= henCost)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-30f, 30f),
                0f,
                Random.Range(-30f, 30f)
            );

            Vector3 spawnPosition = henParent.position + randomOffset;

            Instantiate(henPrefab, spawnPosition, Quaternion.identity, henParent);
            currentHenCount++;
            SpendMoney(henCost);
        }
    }

    public void SpawnHenStart()
    {
        if (currentHenCount < maxHens && money >= henCost)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-30f, 30f),
                0f,
                Random.Range(-30f, 30f)
            );

            Vector3 spawnPosition = henParent.position + randomOffset;

            Instantiate(henPrefab, spawnPosition, Quaternion.identity, henParent);
            SpendMoney(henCost);
        }
    }


    public void SpawnWorker()
    {
        if (money >= workerCost)
        {
            Instantiate(workerPrefab, workerParent);
            SpendMoney(workerCost);
        }
    }

    public void UnlockPopcornMachine()
    {
        if (currentPopcornCount < maxPopcornUnits && money >= popcornMachineCost)
        {
            Instantiate(popcornMachinePrefab, popcornParent);
            currentPopcornCount++;
            SpendMoney(popcornMachineCost);
        }
    }

    public SaveData GetSaveData()
    {
        return new SaveData
        {
            money = money,
            eggCount = eggCount,
            popcornCount = popcornCount,
            currentHenCount = currentHenCount,
            currentPopcornCount = currentPopcornCount
        };
    }

    public void LoadFromSave(SaveData data)
    {
        money = data.money;
        eggCount = data.eggCount;
        popcornCount = data.popcornCount;
        currentHenCount = data.currentHenCount;
        currentPopcornCount = data.currentPopcornCount;

        UIManager.Instance.UpdateUI(money, eggCount, popcornCount);
    }
}

[System.Serializable]
public class SaveData
{
    public int money;
    public int eggCount;
    public int popcornCount;
    public int currentHenCount;
    public int currentPopcornCount;
}