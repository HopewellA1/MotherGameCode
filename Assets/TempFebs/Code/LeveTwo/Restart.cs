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
    void Start()
    {
        int levelOneScore = PlayerPrefs.GetInt("LevelOneScore");
        int levelOtwoScore = PlayerPrefs.GetInt("LevelTowScore");
        Debug.Log("Total one score: " + (levelOneScore+ levelOtwoScore).ToString());
        if (levelOneScore < 10)
        {
            ObjBtnNextLevel.SetActive(false);
            ObjBtnQuit2.SetActive(true);
            ObjBtnQuit.SetActive(false);

        }string msg = "";
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            msg = "Level on score: " + levelOneScore.ToString();
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
            txtcongrats.text = "Total Score: "+ (levelOtwoScore+ levelOneScore) + " Sorry mission is not complete retry";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current level: "+SceneManager.GetActiveScene().buildIndex);
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
