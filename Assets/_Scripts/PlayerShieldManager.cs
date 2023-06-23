using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShieldManager : MonoBehaviour
{
    public float shieldTimer = 0f;
    [SerializeField] private static float shieldTimerMax = 6f;
    [SerializeField] private GameObject shieldObject;
    [SerializeField] private Animator shieldAnimator;
    [SerializeField] private ScoreManager scoreManagerScore;
    [SerializeField] private int scoreForAsteroid = 150;

    void Update()
    {
        if(shieldTimer >= 0f)
        {
            shieldTimer -= Time.deltaTime;
            
            if(shieldTimer <= shieldTimerMax/2)
            {
                ShieldAnimatorActivate();
            }
            else
            {
                shieldAnimator.enabled = false;
            }
        }
        else if(shieldTimer <= 0f)
        {
            ShieldAnimatorDeActivate();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "PowerupShield")
        {
            shieldTimer = shieldTimerMax;
            shieldObject.SetActive(true);
        }
        else if(other.gameObject.tag == "Asteroid")
        {
            scoreManagerScore.score += scoreForAsteroid;
            Debug.Log("ASTEROID DESTROYED! Points: "+ scoreManagerScore.score);
        }
    }

    private void ShieldAnimatorActivate()
    {
        shieldAnimator.enabled = true;
    }

    private void ShieldAnimatorDeActivate()
    {
        shieldAnimator.enabled = false;
        shieldObject.SetActive(false);
    }
}
