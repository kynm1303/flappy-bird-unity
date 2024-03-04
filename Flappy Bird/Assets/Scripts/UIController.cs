using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject idleWindow;
    public GameObject scoreInGame;
    public GameObject gameOverWindow;

    public void SetState(GameState gameState)
    {
        idleWindow.SetActive(false);
        scoreInGame.SetActive(false);
        gameOverWindow.SetActive(false);
        switch (gameState)
        {
            case GameState.IDLE:
                idleWindow.SetActive(true);
                break;
            case GameState.START:
                scoreInGame.SetActive(true);
                break;
            case GameState.GAME_OVER:
                gameOverWindow.SetActive(true);
                break;
        }
    }

    public void UpdateScoreInGame (int score)
    {
        Utils.SetText(scoreInGame, score.ToString());
    }
}