using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    public AudioSource tap, success, gameOver;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void PlayTap() => tap?.Play();
    public void PlaySuccess() => success?.Play();
    public void PlayGameOver() => gameOver?.Play();
}
