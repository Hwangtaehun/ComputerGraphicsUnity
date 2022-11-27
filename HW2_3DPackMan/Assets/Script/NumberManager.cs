using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberManager : MonoBehaviour
{
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
        livesText.text = "³²Àº È½¼ö " + lives;
        if(!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
        }
        saveScore = PlayerPrefs.GetInt("BestScore");

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
        this.scoreText.text = "Á¡¼ö " + score.ToString();
    }

    public void UpdateLife(int ChangeInLives)
    {
        lives += ChangeInLives;
        livesText.text = "³²Àº È½¼ö " + lives;
    }

    public void UpdateEnemycnt()
    {
        enemyCnt--;
    }
}
