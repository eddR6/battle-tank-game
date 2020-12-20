using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text enemiesKilled;
    private int currentScore;
    private int currentEnemiesKilled;
  
    void Start()
    {
        currentScore = 0;
        currentEnemiesKilled = 0;
        GameEvents.EnemyOnDeath += UpdateScore;
        GameEvents.EnemyOnDeath += UpdateEnemiesKilled;
    }
    
    private void UpdateScore()
    {
        if (score == null)
            return;

        currentScore = currentScore + 10;
        score.text = "Score: " + currentScore;
    }

    private void UpdateEnemiesKilled()
    {
        if (score == null)
            return;

        currentEnemiesKilled = currentEnemiesKilled + 1;
        enemiesKilled.text = "Enemies Killed: " + currentEnemiesKilled  ;
    }
}
