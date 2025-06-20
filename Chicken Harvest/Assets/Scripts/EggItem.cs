using UnityEngine;

public class EggItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Worker"))
        {
            GameManager.Instance.AddEggs(1);
            GameManager.Instance.SellEggs(1);
            Destroy(gameObject);
        }
    }
}