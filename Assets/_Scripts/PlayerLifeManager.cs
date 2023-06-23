using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    [SerializeField] private Collider2D scoreTrigger;
    [SerializeField] private GameObject endGameScreen;
    [SerializeField] private GameObject playerShield;
    [SerializeField] private PlayerShieldManager shieldManager;
    [SerializeField] private int lifeCounter = 3;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Asteroid")
        {
            if(!playerShield.activeSelf)
            {
                lifeCounter--;
            }

            if(lifeCounter <= 0)
            {
                scoreTrigger.enabled = false;
                endGameScreen.SetActive(true);
                Destroy(this.gameObject);
            }
        }
        else if(other.gameObject.tag == "PowerupLife")
        {
            lifeCounter++;
        }
        else if(other.gameObject.tag == "PowerupShield")
        {
            playerShield.SetActive(true);
            shieldManager.shieldTimer = 6f;
        }
        
        Debug.Log("Lifes Left: " + lifeCounter);
    }
}
