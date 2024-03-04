using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public static bool TrySetNewHighScore(int newScore)
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (newScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", newScore);
            return true;
        }
        return false;
    }
}
