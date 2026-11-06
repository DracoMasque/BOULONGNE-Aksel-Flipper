using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TextMeshProUGUI scoreText;
    public float score;
    public float objectif = 500;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        RefreshScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        RefreshScoreText();
    }

    void RefreshScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Objectif : " + score + "/" + objectif;
        }
    }
}
