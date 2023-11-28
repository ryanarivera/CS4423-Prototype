using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Text scoreText;
    private int score = -2;

    private void Start()
    {
        UpdateScoreText();
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
