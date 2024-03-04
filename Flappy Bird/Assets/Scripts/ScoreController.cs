using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] scoreTexts;
    [SerializeField]
    private GameObject[] highScoreTexts;

    public int score = 0;
    public int highScore = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void InitScore()
    {
        score = 0;
        this.SetScore(score);
        this.UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleAddScore()
    {
        this.AddScore(1);
        SoundManager.Instance.playSound(SoundType.ScorePoint);
    }

    public void AddScore(int score)
    {
        this.score += score;
        this.SetScore(this.score);
    }

    public void SetScore(int score)
    {
        foreach (GameObject scoreText in scoreTexts) {
            Utils.SetText(scoreText, score.ToString());
        }
    }

    public void UpdateHighScore()
    {
        highScore = Score.GetHighScore();
        foreach (GameObject highScoreText in highScoreTexts)
        {
            Utils.SetText(highScoreText, highScore.ToString());
        }
    }

    public bool CheckHighScore()
    {
        bool isNewHighScore = Score.TrySetNewHighScore(score);
        if (isNewHighScore)
        {
            UpdateHighScore();
        }
        return isNewHighScore;
    }
}
