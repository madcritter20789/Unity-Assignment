using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText, highScoreText;

    public GameObject colorButtons;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        gameOverPanel.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score : " + score;
    }

    public void ShowGameOver(int score, int high)
    {
        gameOverPanel.SetActive(true);
        colorButtons.SetActive(false);
        finalScoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + high;
    }

    public void OnRetry()
    {
        gameOverPanel.SetActive(false);
        GameManager.Instance.RestartGame();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
