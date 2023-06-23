using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject titleText;
    [SerializeField] private GameObject GUIText;
    [SerializeField] private SpawnController spawnController;
    [SerializeField] private Text bestScoreValue;

    private bool isGameStarted = false;
    
    void Start()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreValue.text = bestScore.ToString();

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            titleText.SetActive(false);
            GUIText.SetActive(true);
            spawnController.spawnRate = 2f;
            isGameStarted = true;
        }
    }
}
