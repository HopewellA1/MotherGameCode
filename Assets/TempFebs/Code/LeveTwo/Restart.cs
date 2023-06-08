using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public GameObject ObjBtnNextLevel;
    public GameObject ObjBtnQuit;
    public GameObject ObjBtnQuit2;
    public Text txtScore; 
    public Text txtcongrats;
    //public Text txtHighScoreCongrats;
   // public Text txtAllHighScores;
    //private int highestScore;
    //private int highestScore2;
    //private int highestScore3;
    void Start()
    {
        int levelOneScore = PlayerPrefs.GetInt("LevelOneScore");
        int levelOtwoScore = PlayerPrefs.GetInt("LevelTowScore");
        int TotalScore = levelOneScore + levelOtwoScore;
        //highestScore = PlayerPrefs.GetInt("highestScore");
        //highestScore2 = PlayerPrefs.GetInt("highestScore");
        //highestScore3 = PlayerPrefs.GetInt("highestScore");
        //if (highestScore< TotalScore)
        //{
        //    highestScore3 = highestScore2;
        //    highestScore2 = highestScore;
        //    highestScore = TotalScore;
            
        //   // txtHighScoreCongrats.text = "BIG CONGRATULATIONS, You have broken and created a new record.\nHigh score: " + highestScore.ToString();

        //}
        //else if(highestScore2 < TotalScore)
        //{
        //    highestScore3 = highestScore2;
        //    highestScore2 = TotalScore;
        //  //  txtHighScoreCongrats.text = "CONGRATULATIONS, You have made the second place on the high score list.\nSecond place score: " + highestScore.ToString();

        //}
        //else if (highestScore3 < TotalScore)
        //{
        //    highestScore3 = TotalScore;
        //   // txtHighScoreCongrats.text = "CONGRATULATIONS, You have made the 3rd place on the high score list.\nSecond place score: " + highestScore.ToString();

        //}
        //PlayerPrefs.SetInt("highestScore1", highestScore);
        //PlayerPrefs.SetInt("highestScore2", highestScore2);
        //PlayerPrefs.SetInt("highestScore3", highestScore3);
        //PlayerPrefs.Save();
        //txtAllHighScores.text = "Higest score: " + highestScore;
        //txtAllHighScores.text += "\n2nd place: " + highestScore2;
        //txtAllHighScores.text += "\n3rd place: " + highestScore2;



        if (levelOneScore < 10)
        {
            ObjBtnNextLevel.SetActive(false);
            ObjBtnQuit2.SetActive(true);
            ObjBtnQuit.SetActive(false);

        }string msg = "";
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            msg = "Level one score: " + levelOneScore.ToString();
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            msg = "Level two score: " + levelOtwoScore;
        }
        txtScore.text = msg;
        if(levelOneScore >= 10 &&  levelOtwoScore >= 10){
            txtcongrats.text = "Total Score: " + (levelOtwoScore+ levelOneScore) + " Congratulations mission is complete!";
        }
        else
        {
            txtcongrats.text = "Total Score: "+ (levelOtwoScore+ levelOneScore) + " Sorry mission is not complete please retry. ";
            txtcongrats.text += "\nPlease note that to complete the mission you must get 10 or more point on both levels.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current level: "+SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene( + 1);
    }
    public void btnRestart()
    {
        Debug.Log("restart level Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void btnQuit()
    {
        //Debug.Log("Quit Application Clicked");
         Application.Quit(); 
    }
    public void btnNextLeve()
    {
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void btnNewGame()
    {
       
        

        SceneManager.LoadScene(0);
    }
}
