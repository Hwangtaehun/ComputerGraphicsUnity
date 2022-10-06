using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Text timerText;
    private Text scoreText;
    private float time = 180.0f;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Time").GetComponent<Text>();
        this.scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        IncTimer();
    }

    public void IncScore()
    {
        count += 1;
        this.scoreText.text = "점수 " + count.ToString();
    }

    public void IncTimer()
    {
        int min = 0, sce = 0;
        this.time -= Time.deltaTime;
        min = (int)this.time / 60;
        sce = (int)this.time % 60;
        this.timerText.text = "시간 " + min + "분" + sce + "초";
    }
}
