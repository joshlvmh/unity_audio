using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120.0f;
    public bool timerIsRunning = false;
    private Score score;
    private Text timerText;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;

        // Cache text component and score function to stop tracking score when time has run out
        timerText = this.GetComponent<Text>();
        score = this.transform.parent.GetComponentInChildren<Score>();
    }

    void Update()
    {
        // Check if timer is running
        if (timerIsRunning)
        {
            // See if time has run out, if not, decrease time
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = "Time Remaining: " + timeRemaining.ToString("F0") + " seconds"; 
            }
            // Else game over
            else
            {
                timerText.text = "GAME OVER!";
                score.EndGame();
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}