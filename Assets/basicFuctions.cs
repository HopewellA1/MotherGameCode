using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class basicFuctions : MonoBehaviour
{
    public GameObject snakeOBJ;
    public GameObject basicTop;
    public GameObject PauseManu;
        
    public void btnQuit()
    {
        Application.Quit();
    }
    
    public void btnPause()
    {
        Debug.Log("Pause game!");
        snakeOBJ.SetActive(false);
        basicTop.SetActive(false);
        PauseManu.SetActive(true);
    }
    

    public void btnContinue()
    {
        
        basicTop.SetActive(true);
        PauseManu.SetActive(false);
        snakeOBJ.SetActive(true);
    }
    public void btnRestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void btnNewGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1)
        SceneManager.LoadScene(0);
    }

}
