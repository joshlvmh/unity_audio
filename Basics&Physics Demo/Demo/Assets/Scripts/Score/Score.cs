using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private bool gameOver = false;
    private uint score = 0;
    private Text scoreUI;

    void Start()
    {
        // Get Text Component and set it 
        scoreUI = this.GetComponent<Text>();
        scoreUI.text = "Trees chopped: 0"; 
    }

    public void UpdateScore()
    {
        // If game is still going
        if (!gameOver)
        {
            // Add one to score, change UI text
            score++;
            scoreUI.text = "Trees chopped: " + score.ToString();
        }
    }

    public void EndGame()
    {
        gameOver = true;
    }
}
