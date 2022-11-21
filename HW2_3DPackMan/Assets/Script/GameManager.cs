using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //private Text scoreText;
    //private int score = 0;
    public static bool GameIsPaused = false;

    void Start()
    {
        //this.scoreText = GameObject.Find("Score").GetComponent<Text>();
        Time.timeScale = 1.0f;
        GameIsPaused = true;
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("Title");
    }

    public void BackButton()
    {
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void GamesettingButton()
    {
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void PauseButton()
    {
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ReplayButton()
    {
        SceneManager.LoadScene("Main");
    }
}
