using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Text timerText;
    private Text scoreText;
    private float time = 61.0f;
    private int score = 0;
    private int blockCnt = 0;
    private bool is_gameOver = false;
    public GameObject gameOverPopup;
    public GameObject gameClearPopup;
    public GameObject gameExplainPopup;
    public int ballCnt;
    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Time").GetComponent<Text>();
        this.scoreText = GameObject.Find("Score").GetComponent<Text>();
        livesText.text = "남은 횟수 " + ballCnt;
    }

    // Update is called once per frame
    void Update()
    {
        IncTimer();
        //Debug.Log(time.ToString("F1"));

        if(ballCnt == 0 && blockCnt != 0)
        {
            GameOver();
        }
        else if(blockCnt == 0)
        {
            Invoke("GameClear", 1.0f);
        }
    }

    public void IncScore()
    {
        score += 1;
        this.scoreText.text = "점수 " + score.ToString();
    }

    public void IncTimer()
    {
        
        int min = 0, sce = 0;

        if(time > 0)
        {
            time -= Time.deltaTime;

            min = (int)time / 60;
            sce = (int)time % 60;

            if (min == 0)
            {
                this.timerText.text = "시간 " + sce + "초";
            }
            this.timerText.text = "시간 " + min + "분" + sce + "초";
        }
        else
        {
            GameOver();
        }
       
    }

    public void Count()
    {
        blockCnt++;
    }

    public void Break()
    {
        blockCnt--;
    }

    public void UpdateLife(int ChangeInLives)
    {
        ballCnt += ChangeInLives;
        livesText.text = "남은 횟수 " + ballCnt;
    }

    //public void LoseBall()
    //{
    //    ballCnt--;
    //}

    public void GameClear()
    {
        if (is_gameOver == false)
        {
            gameClearPopup.SetActive(true);
            Time.timeScale = 0.0f;
            is_gameOver = true;
        }
    }

    public void GameOver()
    {
        if(is_gameOver == false)
        {
            gameOverPopup.SetActive(true);
            Time.timeScale = 0.0f;
            is_gameOver = true;
        }
    }

    public void GameExplain()
    {
        gameExplainPopup.SetActive(false);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
