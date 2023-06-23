using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreTrigger;
    [SerializeField] private GameObject PlayerShield;
    [SerializeField] private PlayerShieldManager shieldManager;
    [SerializeField] private int lifeCounter = 3;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Asteroid")
        {
            if(!PlayerShield.activeSelf)
            {
                lifeCounter--;
            }

            if(lifeCounter <= 0)
            {
                Destroy(scoreTrigger);
                Destroy(this.gameObject);
            }
        }
        else if(other.gameObject.tag == "PowerupLife")
        {
            lifeCounter++;
        }
        else if(other.gameObject.tag == "PowerupShield")
        {
            PlayerShield.SetActive(true);
            shieldManager.shieldTimer = 6f;
        }
        
        Debug.Log("Lifes Left: " + lifeCounter);
    }
}
