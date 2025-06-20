using UnityEngine;

public class CustomerInteraction : MonoBehaviour
{
    public enum CustomerType { EggBuyer, PopcornBuyer }
    public CustomerType customerType;

    public Transform startPoint;
    public Transform stopPoint;
    public Transform exitPoint;
    public float moveSpeed = 2f;

    private CharacterController controller;
    private bool isWaitingAtStop = false;
    private bool isExiting = false;

    public Animator animator;
    private float stopThreshold = 0.5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isWaitingAtStop && !isExiting)
        {
            // Walk toward stopPoint
            float dist = Vector3.Distance(transform.position, stopPoint.position);
            if (dist > stopThreshold)
            {
                Vector3 dir = (stopPoint.position - transform.position).normalized;
                dir.y = 0;
                controller.Move(dir * moveSpeed * Time.deltaTime);
                transform.forward = dir;
                animator.SetBool("isWalking", true);
            }
            else
            {
                // Arrived: switch to idle
                isWaitingAtStop = true;
                animator.SetBool("isWalking", false);
            }
        }
        else if (isExiting)
        {
            // Walk toward exitPoint
            float dist = Vector3.Distance(transform.position, exitPoint.position);
            if (dist > stopThreshold)
            {
                Vector3 dir = (exitPoint.position - transform.position).normalized;
                dir.y = 0;
                controller.Move(dir * moveSpeed * Time.deltaTime);
                transform.forward = dir;
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
                Destroy(gameObject, 1f);
            }
        }
    }

    /// <summary>
    /// Returned true when at stop point and still waiting for a transaction.
    /// </summary>
    public bool IsWaiting()
    {
        return isWaitingAtStop && !isExiting;
    }

    /// <summary>
    /// Called by the Player to mark the sale done. Customer will leave on next Update().
    /// </summary>
    public void MarkTransactionComplete()
    {
        if (!isWaitingAtStop || isExiting) return;
        isExiting = true;
        isWaitingAtStop = false;
    }
}
