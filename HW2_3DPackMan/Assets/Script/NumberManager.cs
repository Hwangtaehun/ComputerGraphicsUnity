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

    void Start()
    {
        this.scoreText = GameObject.Find("Score").GetComponent<Text>();
        this.livesText = GameObject.Find("Lives").GetComponent<Text>();
        livesText.text = "³²Àº È½¼ö " + lives;
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SceneManager.LoadScene("Success");
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
}
