using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    float curTime = 0.0f;
    string timerText;
    private AudioSource audio;
    public float jumpPower;
    public AudioClip jumpSound;

    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;

        if(Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            this.audio.Play();
        }
    }

    void OnGUI()
    {
        string timerText = "Timer : " + (int)curTime;
        Rect textPos = new Rect(100, 100, 200, 40);
        GUI.Label(textPos, timerText);
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("Main");
    }
}
