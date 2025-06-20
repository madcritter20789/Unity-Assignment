using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Joystick joystick;
    public float speed = 5f;
    private Vector3 move;

    void Update()
    {
        float h = joystick.Horizontal;
        float v = joystick.Vertical;
        move = new Vector3(h, 0, v);

        if (move.magnitude > 0.1f)
        {
            controller.Move(move.normalized * speed * Time.deltaTime);
            transform.forward = move;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            GameManager.Instance.AddEggs(1);
            GameManager.Instance.SellEggs(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Corn"))
        {
            PopcornMachine machine = FindObjectOfType<PopcornMachine>();
            if (machine != null)
            {
                machine.AddCorn(1);
            }
            Destroy(other.gameObject);
        }
    }
}