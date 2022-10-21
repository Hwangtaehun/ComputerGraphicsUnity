using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Text timerText;
    private Text scoreText;
    private Text livesText;
    private float time = 60.0f;
    private int score = 0;
    private int bonusballCnt = 0;
    private int ballCnt = 3;
    private int blockCnt = 0;
    private bool is_gameOver = false;
    private bool isBallInPlay = false;
    public GameObject gameOverPopup;
    public GameObject gameClearPopup;
    public GameObject gameExplainPopup;

    // Start is called before the first frame update
    void Start()
    {
        time += 1;
        this.timerText = GameObject.Find("Time").GetComponent<Text>();
        this.scoreText = GameObject.Find("Score").GetComponent<Text>();
        this.livesText = GameObject.Find("Lives").GetComponent<Text>();
        livesText.text = "남은 횟수 " + ballCnt;
    }

    // Update is called once per frame
    void Update()
    {
        IncTimer();

        if (ballCnt == 0)
        {
            GameOver();
        }
        else if (blockCnt == 0)
        {
            GameClear();
        }

        //Debug.Log(time.ToString("F1"));
    }

    public void IncScore(int ChangeScore)
    {
        score += ChangeScore;
        if (score < 0)
            score = 0;
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
        if (bonusballCnt == 0)
        {
            ballCnt += ChangeInLives;
            livesText.text = "남은 횟수 " + ballCnt;
            if (ChangeInLives < 0)
            {
                GameObject ball = GameObject.Find("BallGenerator");
                ball.GetComponent<BallGenerator>().ballDestroy();
                isBallInPlay = false;
            }
        }
        else
            bonusballCnt--;
    }

    public void BonusBall()
    {
        if (isBallInPlay == true)
        {
            if (bonusballCnt < 2)
            {
                GameObject ball = GameObject.Find("BallGenerator");
                ball.GetComponent<BallGenerator>().makeBall();
                bonusballCnt++;
            }
        }
        //Debug.Log(bonusballCnt);
    }

    public void UpdateBlockCnt(int ChangeInBlock)
    {
        blockCnt += ChangeInBlock;
    }

    public void GameClear()
    {
        if (is_gameOver == false)
        {
            gameClearPopup.SetActive(true);
            Time.timeScale = 0.0f;
            is_gameOver = true;
        }
    }

    public void Gameplay()
    {
        isBallInPlay = true;
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
