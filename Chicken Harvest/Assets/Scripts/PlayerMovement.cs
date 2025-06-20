using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public CharacterController controller;
    public Animator anim;

    [Header("Joystick Reference")]
    public Joystick joystick; // Assign in inspector

    [Header("Movement Settings")]
    public float moveSpeed = 10f;
    public float gravity = -9.81f;

    private Vector3 velocity;
    private Vector3 direction;

    [Header("PayApp Settings")]
    public float transactionRadius = 2f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        MovePlayer();
        TryPayAppTransaction(); // Check nearby customers automatically
    }

    void MovePlayer()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            controller.Move(direction.normalized * moveSpeed * Time.deltaTime);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            GameManager.Instance.AddEggs(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Corn"))
        {
            GameManager.Instance.AddPopcorn(1);
            Destroy(other.gameObject);
        }
    }

    void TryPayAppTransaction()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, transactionRadius);
        foreach (var col in hits)
        {
            var customer = col.GetComponent<CustomerInteraction>();
            if (customer != null && customer.IsWaiting())
            {
                switch (customer.customerType)
                {
                    case CustomerInteraction.CustomerType.EggBuyer:
                        int eggs = Mathf.Min(GameManager.Instance.eggCount, 5);
                        if (eggs > 0)
                        {
                            GameManager.Instance.SellEggs(eggs);
                            Debug.Log($"Sold {eggs} eggs to customer.");
                        }
                        else
                        {
                            Debug.Log("Not enough eggs to sell.");
                        }
                        break;

                    case CustomerInteraction.CustomerType.PopcornBuyer:
                        int popcorn = Mathf.Min(GameManager.Instance.popcornCount, 3);
                        if (popcorn > 0)
                        {
                            GameManager.Instance.SellPopcorn(popcorn);
                            Debug.Log($"Sold {popcorn} popcorn to customer.");
                        }
                        else
                        {
                            Debug.Log("Not enough popcorn to sell.");
                        }
                        break;
                }

                customer.MarkTransactionComplete(); // Tells customer to walk away
                break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, transactionRadius);
    }
}
