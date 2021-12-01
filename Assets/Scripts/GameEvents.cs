using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents 
{
    public static Action<GameObject> OnEnemyHit = null;
    public static Action<GameObject> OnEnemyDied = null;
    public static Action<GameObject> OnPlayerHit = null;
    public static Action<GameObject> OnPlayerDied = null;
   // public static event Action<GameState> OnGameStateChange = null;
    // public static event Action<Difficulty> OnDifficultyChange = null;

    public static void ReportEnemyHit(GameObject _enemy)
    {
        Debug.Log("Enemy" + _enemy.name + "was hit");
        OnEnemyHit?.Invoke(_enemy);
    }

    public static void ReportEnemyDied(GameObject _enemy)
    {
        Debug.Log("Enemy" + _enemy.name + "died");
        OnEnemyDied?.Invoke(_enemy);
    }


    public static void ReportPlayerHit(GameObject _Player)
    {
      
        OnEnemyHit?.Invoke(_Player);
    }

    public static void ReportPlayerDied(GameObject _Player)
    {
        
        OnEnemyDied?.Invoke(_Player);
        //ReportGameStateChange(GameState.GameOver);
    }

  //  public static void ReportGameStateChange(GameState _gameState)
  //  {
   //     OnGameStateChange?.Invoke(_gameState);
  //  }

    /*   public static void ReportDifficultyChange(Difficulty _difficulty)
      {
          OnDifficultyChange?.Invoke(_difficulty);
      }*/
}
