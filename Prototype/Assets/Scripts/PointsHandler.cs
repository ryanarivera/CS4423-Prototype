using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsHandler : MonoBehaviour
{
    //[SerializeField] float distanceTranveled = 0f;
    public static PointsHandler singleton;
    private int score = 0;
    public Text scoreText;

    void Awake(){
        if(singleton == null){
            singleton = this;
            LoadScore();
        }else{
            Destroy(this.gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void OnDestroy()
    {
        SaveScore();  // Save the score when the GameObject is destroyed
    }

    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreText();
        // Additional logic related to updating UI or other game elements based on the score
    }

    public void DecreaseScore(int points)
    {
        score -= points;
        UpdateScoreText();
        // Additional logic related to updating UI or other game elements based on the score
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Coins: " + score.ToString();
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    private void LoadScore()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
            
        }else
        {
            // If no saved score is found, reset the score to zero
            score = 0;
            SaveScore(); // Save the reset score
        }

        UpdateScoreText();
    }

    public void ResetScore()
    {
        score += 10;
        UpdateScoreText();
        SaveScore();
    }

    // public void AddTenScore()
    // {
    //     score += 10;
    //     UpdateScoreText();

    //     SaveScore();
    // }

}
