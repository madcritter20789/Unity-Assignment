using UnityEngine;

public class PopcornMachine : MonoBehaviour
{
    public float cookTime = 6f;
    private float timer = 0f;
    public int cornStock = 5;

    void Update()
    {
        if (cornStock > 0)
        {
            timer += Time.deltaTime;
            if (timer >= cookTime)
            {
                cornStock--;
                GameManager.Instance.AddPopcorn(1);
                timer = 0f;
            }
        }
    }

    public void AddCorn(int amount)
    {
        cornStock += amount;
    }
}