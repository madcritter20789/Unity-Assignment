using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerColor { Red, Green, Blue }

public class PlayerController : MonoBehaviour
{
    [Header("Color Tap Buttons (for mobile)")]
    public GameObject redButton;
    public GameObject greenButton;
    public GameObject blueButton;

    [Header("Success Particle Effects")]
    public GameObject redEffectPrefab;
    public GameObject greenEffectPrefab;
    public GameObject blueEffectPrefab;


    public SpriteRenderer spriteRenderer;
    public Color red, green, blue;

    public PlayerColor currentColor;

    public void ChangeColor(int colorIndex)
    {
        currentColor = (PlayerColor)colorIndex;
        switch (currentColor)
        {
            case PlayerColor.Red:
                spriteRenderer.color = red;
                break;
            case PlayerColor.Green:
                spriteRenderer.color = green;
                break;
            case PlayerColor.Blue:
                spriteRenderer.color = blue;
                break;
        }

        AudioManager.Instance?.PlayTap();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Gate gate))
        {
            if (gate.color == currentColor)
            {
                GameManager.Instance.AddScore();

                // Plays matching particle effect at gate position
                GameObject prefabToSpawn = null;

                switch (gate.color)
                {
                    case PlayerColor.Red: prefabToSpawn = redEffectPrefab; break;
                    case PlayerColor.Green: prefabToSpawn = greenEffectPrefab; break;
                    case PlayerColor.Blue: prefabToSpawn = blueEffectPrefab; break;
                }

                if (prefabToSpawn != null)
                {
                    Instantiate(prefabToSpawn, gate.transform.position, Quaternion.identity);
                }


                AudioManager.Instance?.PlaySuccess();
                gate.gameObject.SetActive(false);

            }
            else
            {
                AudioManager.Instance?.PlayGameOver();
                GameManager.Instance.GameOver();
            }
        }
    }

}
