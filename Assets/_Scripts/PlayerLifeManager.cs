using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreTrigger;
    [SerializeField] private int lifeCounter = 3;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Asteroid")
        {
            lifeCounter--;

            if(lifeCounter <= 0)
            {
                Destroy(scoreTrigger);
                Destroy(this.gameObject);
            }
        }
        else
        {
            lifeCounter++;
        }
        
        Debug.Log("Lifes Left: " + lifeCounter);
    }
}
