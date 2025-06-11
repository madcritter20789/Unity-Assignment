using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Sprite redSprite, greenSprite, blueSprite; // With patterns or labels

    // Update is called once per frame
    public SpriteRenderer spriteRenderer;
    public PlayerColor color;
    public Color red, green, blue;

    private float moveSpeed = 5f;

    public void Initialize(PlayerColor col, float speed)
    {
        color = col;
        moveSpeed = speed;

        switch (color)
        {
            case PlayerColor.Red:
                spriteRenderer.color = red;
                spriteRenderer.sprite = redSprite;
                break;
            case PlayerColor.Green:
                spriteRenderer.color = green;
                spriteRenderer.sprite = greenSprite;
                break;
            case PlayerColor.Blue:
                spriteRenderer.color = blue;
                spriteRenderer.sprite = blueSprite;
                break;
        }

    }

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -10f)
        {
            gameObject.SetActive(false);
        }
    }
}
