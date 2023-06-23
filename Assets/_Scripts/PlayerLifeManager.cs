using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeManager : MonoBehaviour
{
    public int lifeCounter = 3;
    [SerializeField] private Collider2D scoreTrigger;
    [SerializeField] private GameObject endGameScreen;
    [SerializeField] private GameObject playerShield;
    [SerializeField] private PlayerShieldManager shieldManager;
    [SerializeField] private Text lifeText;
    
    void Start()
    {
        UILifeUpdate();
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Asteroid")
        {
            if(!playerShield.activeSelf)
            {
                lifeCounter--;
                UILifeUpdate();
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
            UILifeUpdate();
        }
        else if(other.gameObject.tag == "PowerupShield")
        {
            playerShield.SetActive(true);
            shieldManager.shieldTimer = 6f;
        }
        
        Debug.Log("Lifes Left: " + lifeCounter);
    }

    public void UILifeUpdate()
    {
        lifeText.text = lifeCounter.ToString();
    }
}
