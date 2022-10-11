using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Text timerText;
    private Text scoreText;
    private float time = 60.0f;
    private int score = 0;
    private bool is_gameOver = false;
    public GameObject gameOverPopup;
    public GameObject gameClearPopup;
    public GameObject gameExplainPopup;
    public int ballCnt;
    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        time += 1;
        this.timerText = GameObject.Find("Time").GetComponent<Text>();
        this.scoreText = GameObject.Find("Score").GetComponent<Text>();
        livesText.text = "남은 횟수 " + ballCnt;
    }

    // Update is called once per frame
    void Update()
    {
        IncTimer();
        //Debug.Log(time.ToString("F1"));

        if (ballCnt == 0 && score < 50)
        {
            GameOver();
        }
        else if (score >= 50)
        {
            GameClear();
        }
    }

    public void IncScore()
    {
        score += 10;
        this.scoreText.text = "점수 " + score.ToString();
    }

    public void IncTimer()
    {


        if (time > 0)
        {
            time -= Time.deltaTime;
            int min = (int)time / 60;
            int sce = (int)time % 60;

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
        if (is_gameOver == false)
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
