using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
  public enum GameState
    {
        Title,
        Playing,
        Paused,
        GameOver
    }
    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    public GameState gameState;
    public Difficulty difficulty;

    private void Start()
    {
        ChangeDifficulty();
    }

    public void ChangeDifficulty()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
               //max enemies//health
                break;
            case Difficulty.Medium:
               //
                break;
            case Difficulty.Hard:
               //
                break;
        }
    }
    public void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
    }

    private void OnEnable()
    {
      //  GameEvents.OnEnemyHit += OnEnemyHit;
     //   GameEvents.OnEnemyDied += OnEnemyDied;
    }
    private void OnDisable()
    {
      //  GameEvents.OnEnemyHit -= OnEnemyHit;
      //  GameEvents.OnEnemyDied -= OnEnemyDied;

    }
}
