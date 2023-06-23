using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    void Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        int currentScore = scoreManager.score;
        
        Debug.Log("Your Score is " + currentScore);
        
        if(bestScore > currentScore || bestScore == currentScore)
        {
            Debug.Log("Best score is " + bestScore);
        }
        else if(bestScore < currentScore)
        {
            Debug.Log("NEW BEST SCORE");
            PlayerPrefs.SetInt("BestScore", currentScore);
        }
    }
}
