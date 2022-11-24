using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberManager : MonoBehaviour
{
    private Text scoreText;
    private int score = 0;

    void Start()
    {
        this.scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SceneManager.LoadScene("Success");
        }
    }

    public void IncScore(int ChangeScore)
    {
        score += ChangeScore;
        if (score < 0)
            score = 0;
        this.scoreText.text = "Á¡¼ö " + score.ToString();
    }
}
