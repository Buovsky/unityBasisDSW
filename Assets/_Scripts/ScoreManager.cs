using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        score += 100;
        Debug.Log(score);
    }
}
