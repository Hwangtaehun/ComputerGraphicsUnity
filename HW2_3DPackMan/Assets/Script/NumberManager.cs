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
    private bool working = true;

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

        if (working == true)
        {
            if (GameObject.FindGameObjectsWithTag("Dot").Length == 0)
            {
                working = false;
                GameObject enemy = GameObject.Find("Enemy");
                enemy.GetComponent<Enemy>().RunTure();
                GameObject enemy2 = GameObject.Find("Enemy2");
                enemy2.GetComponent<Enemy>().RunTure();
                GameObject cube1 = GameObject.Find("LeftMoveBlack");
                cube1.GetComponent<CubeMoveZ>().moveStop();
                GameObject cube2 = GameObject.Find("RightMoveBlack");
                cube2.GetComponent<CubeMoveZ>().moveStop();
                GameObject cube3 = GameObject.Find("UpDownCube");
                cube3.GetComponent<CubeUpDown>().moveStop();
                GameObject Player = GameObject.Find("Player");
                Player.GetComponent<Player>().Attack();
            }
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
