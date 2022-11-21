using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeManger : MonoBehaviour
{
    private Text timerText;
    private float time = 180.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Time").GetComponent<Text>();
    }

    // Update is called once per frame
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
                this.timerText.text = "�ð� " + sce + "��";
            }
            this.timerText.text = "�ð� " + min + "��" + sce + "��";
        }
        else
        {
            SceneManager.LoadScene("Failure");
        }
    }
}
