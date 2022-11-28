using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberManager : MonoBehaviour
{
    private Text bestScoreText;
    private Text scoreText;
    private Text livesText;
    private int score = 0;
    private int lives = 3;
    private int enemyCnt = 2;
    private int saveScore;

    void Start()
    {
        this.scoreText = GameObject.Find("Score").GetComponent<Text>();
        this.livesText = GameObject.Find("Lives").GetComponent<Text>();
        livesText.text = "남은 횟수 " + lives;
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
        saveScore = PlayerPrefs.GetInt("BestScore");
        this.bestScoreText = GameObject.Find("BestScore").GetComponent<Text>();
        this.bestScoreText.text = "최고 점수 " + saveScore.ToString();

    }

    void Update()
    {
        if (enemyCnt == 0)
        {
            PlayerPrefs.SetInt("ScoreData", score);
            SceneManager.LoadScene("Success");

            if(saveScore < score)
            {
                PlayerPrefs.SetInt("BestScore", score);
            }
        }

        if(lives == 0)
        {
            SceneManager.LoadScene("Failure");
        }
    }

    public void IncScore(int ChangeScore)
    {
        score += ChangeScore;
        if (score < 0)
            score = 0;
        this.scoreText.text = "점수 " + score.ToString();
    }

    public void UpdateLife(int ChangeInLives)
    {
        lives += ChangeInLives;
        livesText.text = "남은 횟수 " + lives;
    }

    public void UpdateEnemycnt()
    {
        enemyCnt--;
    }
}
