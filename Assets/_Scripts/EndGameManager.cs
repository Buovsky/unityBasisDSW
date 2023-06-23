using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text bestScoreValue;
    private bool restartDelayBool = false;
    void Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        int currentScore = scoreManager.score;
        gameOverCanvas.SetActive(true);
        
        Debug.Log("Your Score is " + currentScore);
        
        if(bestScore > currentScore || bestScore == currentScore)
        {
            Debug.Log("Best score is " + bestScore);
            bestScoreValue.text = bestScore.ToString();
        }
        else if(bestScore < currentScore)
        {
            Debug.Log("NEW BEST SCORE");
            PlayerPrefs.SetInt("BestScore", currentScore);
            bestScoreText.text = "NEW BEST SCORE!";
            bestScoreValue.text = currentScore.ToString();
        }

        Invoke("RestartDelay", 1.5f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && restartDelayBool)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    private void RestartDelay()
    {
        restartDelayBool = true;
    }
}
