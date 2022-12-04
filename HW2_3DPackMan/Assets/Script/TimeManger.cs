using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManger : MonoBehaviour
{
    private Text timerText;
    private float time = 180.0f;

    void Start()
    {
        this.timerText = GameObject.Find("Time").GetComponent<Text>();
    }

    void Update()
    {
        IncTimer();
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
            SceneManager.LoadScene("Failure");
        }
    }
}
