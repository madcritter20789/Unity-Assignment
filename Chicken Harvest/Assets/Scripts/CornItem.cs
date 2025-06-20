using UnityEngine;

public class CornItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Worker"))
        {
            PopcornMachine machine = FindObjectOfType<PopcornMachine>();
            if (machine != null)
            {
                machine.AddCorn(1);
            }
            Destroy(gameObject);
        }
    }
}