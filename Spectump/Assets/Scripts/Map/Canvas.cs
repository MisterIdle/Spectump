using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Canvas : MonoBehaviour
{
    public TMPro.TMP_Text timerText;
    public TMPro.TMP_Text gameOverText;
    float time;
    public bool isGameOver = false;

    public void Start()
    {
        gameOverText.enabled = false;
        time = Time.time - Time.time;
    }

    public void Update()
    {
        if (!isGameOver)
        {
            Timer();
        }
    }

    private void Timer()
    {
        time += Time.deltaTime; // Utiliser Time.deltaTime au lieu de Time.time
        timerText.text = "Temps: " + time.ToString("F2");
    }

    public void GameOver()
    {
        isGameOver = true;
        timerText.enabled = false;
        gameOverText.text = "Game Over: " + time.ToString("F2");
        gameOverText.enabled = true;
    }
}
