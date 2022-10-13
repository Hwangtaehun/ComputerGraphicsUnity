using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    private bool isBallInPlay = false;
    public GameObject ballPrefab;
    public float speed = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) == true && isBallInPlay == false)
        {
            Time.timeScale = 1.0f;
            isBallInPlay = true;
            GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
            Vector3 dir = new Vector3(speed, 0, speed);
            BallController ballController = ball.GetComponent<BallController>();
            ballController.play(dir);
        }
    }

    public void ballDestroy()
    {
        isBallInPlay = false;
    }

    public void makeBall()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
        Vector3 dir = new Vector3(speed, 0, speed);
        BallController ballController = ball.GetComponent<BallController>();
        ballController.play(dir);
        //GameObject manager = GameObject.Find("GameManager");
        //manager.GetComponent<GameManager>().BonusBall();
    }

    //private void OnTriggerEnter(Collider Coll)
    //{
    //    if (Coll.gameObject.name == "DeadZone")
    //    {
    //        isBallInPlay = false;
    //        GameObject manager = GameObject.Find("GameManager");
    //        manager.GetComponent<GameManager>().UpdateLife(-1);
    //        Destroy(gameObject);
    //    }
    //}
}
