using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class GameManager2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject snakeObject;
    public GameObject DangersnakeObject;
    public GameObject floorObject;
    public GameObject TheSpike;
    public Text gameOverText;
    public float timerDuration = 60f; // Total duration of the timer in seconds
     // Total duration of the timer in seconds
    public Text timerText;
    public Text deciderText;
    
    private float timer;
    public SnakeControllerLevelTwo snakeController;
    public SpikeEat2 spikeEat;
 


    private void Start()
    {
       
    
        timer = timerDuration; // Set initial timer value
        UpdateTimerDisplay();
        //snakeObject.GetComponent<SnakeController>().enabled = false;
        //TheSpike.GetComponent<SpikeEat>().enabled = false;
    }
    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime; // Decrease the timer by the elapsed time since the last frame
            UpdateTimerDisplay();
        }
        else
        {
            Debug.Log("The game is over");
            GameOver();
           
           

        }
        
    }
    public void GameOver()
    {
        // Disable the snake object's movement and input
        snakeObject.GetComponent<SnakeControllerLevelTwo>().enabled = false;
        DangersnakeObject.GetComponent<ControlDanger>().enabled = false;  


        // Display "Game Over" text
        gameOverText.text = "Game Over!";
        if (snakeController != null)
        {
            if (snakeController.numApples >= 10)
            {
                deciderText.text = "YOU WoN!.";
            }
            else
            {
                if (snakeController.numApples < 10)
                {
                    deciderText.text = "YOU LOST!";
                }
            }
            SaveScore(snakeController.numApples);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.name == "body")
        {
            Debug.Log("body");
            // Trigger game over
            GameOver();
        }

    }
    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        // Format the time as a string in mm:ss format
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Display the time on the timerText UI component
        timerText.text = "Time: " + timeString;
    }
   
    public static void SaveScore(int score)
    {
        PlayerPrefs.SetInt("LevelTowScore", score);
        PlayerPrefs.Save();
    }
    public void restartLevel()
    {
       //
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        Debug.Log("Clicked");   
    }
}
