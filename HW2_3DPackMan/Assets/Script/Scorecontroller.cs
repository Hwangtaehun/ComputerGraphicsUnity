using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorecontroller : MonoBehaviour
{
    private int bestScore = 0;
    private int score = 0;
    private Text scoreText;
    private Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("ScoreData");
        this.scoreText = GameObject.Find("Score").GetComponent<Text>();
        this.scoreText.text = "점수 " + score.ToString();
        bestScore = PlayerPrefs.GetInt("BestScore");
        this.bestScoreText = GameObject.Find("BestScore").GetComponent<Text>();
        this.bestScoreText.text = "최고 점수 " + bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
