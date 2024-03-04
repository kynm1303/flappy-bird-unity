using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
    IDLE,
    START,
    GAME_OVER
}

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public GameState gameState;
    public PlayerController playerController;
    public UIController uiController;
    private ColliderController colliderController;
    public ScoreController scoreController;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        uiController = GetComponent<UIController>();
        this.colliderController = new ColliderController();
        this.scoreController = GetComponent<ScoreController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        changeGameState(GameState.IDLE);
    }

    public void changeGameState(GameState gameState) {
        uiController.SetState(gameState);
        switch (gameState)
        {
            case GameState.IDLE:
                this.playerController.InitBird();
                this.scoreController.InitScore();
                break;
            case GameState.START:
                break;
            case GameState.GAME_OVER:
                scoreController.CheckHighScore();
                SoundManager.Instance.playSound(SoundType.BirdDie);
                break;
        }
        this.gameState = gameState;
    }

    public void StartNewGame()
    {
        changeGameState(GameState.START);
    }

    public void ChangeToIdle()
    {
        changeGameState(GameState.IDLE);
        clearAllPipes();
    }

    private void clearAllPipes()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach(GameObject pipe in pipes)
        {
            Destroy(pipe);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.START)
            colliderController.checkForCollide();
        else if (gameState == GameState.IDLE)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                this.StartNewGame();
            }
        }
    }
}