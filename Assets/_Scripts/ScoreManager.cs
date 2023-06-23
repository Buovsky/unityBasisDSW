using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private Text scoreText;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Asteroid")
        {
            score += 100;
            UIScoreUpdate();
            Debug.Log(score);
        }
    }

    public void UIScoreUpdate()
    {
        scoreText.text = score.ToString();
    }
}
