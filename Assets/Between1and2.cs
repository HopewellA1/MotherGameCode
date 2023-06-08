using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Between1and2 : MonoBehaviour
{
    public Text txtcongrats;
    public GameObject btnQuit2;
    public GameObject btnQuit;
    public GameObject btnNextLevel;
    void Start()
    {
        string msg = "";
        int levelOneScore = PlayerPrefs.GetInt("LevelOneScore");    
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            msg = "Level one score: " + levelOneScore.ToString();
            if (levelOneScore >= 10)
            {
                msg += ", Congratulations you may proceed to the next level.";
            }
            else
            {
                msg += ", Sorry the first mission not complete please retry.";
                btnNextLevel.SetActive(false);
                btnQuit2.SetActive(true);
                btnQuit.SetActive(false);
            }
            txtcongrats.text = msg;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
