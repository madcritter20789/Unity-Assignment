using System.Collections;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public GameObject eggCustomerPrefab;
    public GameObject popcornCustomerPrefab;

    public Transform spawnPoint;
    public Transform stopPoint;
    public Transform exitPoint;

    public float spawnInterval = 10f;

    void Start()
    {
        StartCoroutine(SpawnCustomerRoutine());
    }

    IEnumerator SpawnCustomerRoutine()
    {
        while (true)
        {
            SpawnCustomer();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnCustomer()
    {
        // Always spawn egg customer
        GameObject eggCustomer = Instantiate(eggCustomerPrefab, spawnPoint.position, Quaternion.identity);
        SetupCustomer(eggCustomer, stopPoint, exitPoint);

        // Conditionally spawn popcorn customer
        if (GameManager.Instance.popcornUnlocked)  // You must implement popcornUnlocked bool in GameManager
        {
            GameObject popcornCustomer = Instantiate(popcornCustomerPrefab, spawnPoint.position, Quaternion.identity);
            SetupCustomer(popcornCustomer, stopPoint, exitPoint);
        }
    }

    void SetupCustomer(GameObject customer, Transform stop, Transform exit)
    {
        CustomerInteraction interaction = customer.GetComponent<CustomerInteraction>();
        interaction.startPoint = spawnPoint;
        interaction.stopPoint = stop;
        interaction.exitPoint = exit;
    }
}
