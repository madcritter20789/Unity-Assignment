using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWorker : MonoBehaviour
{
    private float moveTimer = 0f;
    public float moveInterval = 5f;

    void Update()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveInterval)
        {
            CollectNearbyItems();
            moveTimer = 0f;
        }
    }

    void CollectNearbyItems()
    {
        Collider[] items = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in items)
        {
            if (col.CompareTag("Egg"))
            {
                GameManager.Instance.AddEggs(1);
                //GameManager.Instance.SellEggs(1);
                Destroy(col.gameObject);
            }
            else if (col.CompareTag("Corn"))
            {
                PopcornMachine machine = FindObjectOfType<PopcornMachine>();
                if (machine != null)
                {
                    machine.AddCorn(1);
                }
                Destroy(col.gameObject);
            }
        }
    }
}
