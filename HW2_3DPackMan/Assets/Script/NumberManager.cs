using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    private Text scoreText;
    private int score = 0;

    void Start()
    {
        this.scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    public void IncScore(int ChangeScore)
    {
        score += ChangeScore;
        if (score < 0)
            score = 0;
        this.scoreText.text = "Á¡¼ö " + score.ToString();
    }
}
