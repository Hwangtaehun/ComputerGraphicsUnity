using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 200.0f;
    Vector3 startPos;
    //private Rigidbody ballRd;
    //private bool isBallInPlay = false;
    // public Transform player;
    // public GameManager gm;
    //private int bonusBall = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(0, 0, 0);
        //Time.timeScale = 0.0f;
        //ballRd = GetComponent<Rigidbody>();
        //transform.position = player.position + new Vector3(0, 0, 0.5f);
    }

    // Update is called once per frame
    public void Update()
    {
        //Vector3 dir = new Vector3(speed, 0, speed);
        //if (transform.position.z < 86)
        //{
        //    transform.position = new Vector3(17.0f, -5.0f, 85.0f);
        //    transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        //}
        //else if (Input.GetKey(KeyCode.Space) == true && isBallInPlay == false)
        //{
        //    Rigidbody ballRd = GetComponent<Rigidbody>();
        //    GameObject manager = GameObject.Find("GameManager");
        //    manager.GetComponent<GameManager>().GameExplain();
        //    Time.timeScale = 1.0f;
        //    isBallInPlay = true;
        //    ballRd.isKinematic = false;
        //    play(dir);
        //}

    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody ballRd = GetComponent<Rigidbody>();

        if (collision.gameObject.CompareTag("WALL"))
        {
            Vector3 currPos = collision.transform.position;

            Vector3 incomVec = currPos - startPos;
            Vector3 normalVec = collision.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            reflectVec = reflectVec.normalized;

            ballRd.AddForce(reflectVec * speed);
        }
        else if (collision.gameObject.CompareTag("BLOCK"))
        {
            Vector3 currPos = collision.transform.position;

            Vector3 incomVec = currPos - startPos;
            Vector3 normalVec = collision.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            reflectVec = reflectVec.normalized;

            ballRd.AddForce(reflectVec * speed);

            Destroy(collision.gameObject);
            GameObject manager = GameObject.Find("GameManager");
            manager.GetComponent<GameManager>().IncScore(5);
            manager.GetComponent<GameManager>().UpdateBlockCnt(-1);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 currPos = collision.transform.position;

            Vector3 incomVec = currPos - startPos;
            Vector3 normalVec = collision.contacts[0].normal;
            Vector3 reflectVec = Vector3.Reflect(incomVec, normalVec);
            reflectVec = reflectVec.normalized;

            ballRd.AddForce(reflectVec * speed);
        }
        startPos = transform.position;
    }

    private void OnTriggerEnter(Collider Coll)
    {
        if (Coll.gameObject.name == "Small")
        {
            if (this.transform.localScale.x >= 0.5f)
            {
                transform.localScale = this.transform.localScale * 0.9f;
            }
            //transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
        else if (Coll.gameObject.name == "DeadZone")
        {
            GameObject manager = GameObject.Find("GameManager");
            manager.GetComponent<GameManager>().UpdateLife(-1);
            Destroy(gameObject);
            //isBallInPlay = false;
            // Debug.Log(bonusBall);
            //if (bonusBall == 0)
            //{
            //    GameObject manager = GameObject.Find("GameManager");
            //    manager.GetComponent<GameManager>().UpdateLife(-1);
            //}
            //else
            //    bonusBall--;
            //gm.UpdateLife(-1);
        }
    }

    public void play(Vector3 dir)
    {
        Rigidbody ballRd = GetComponent<Rigidbody>();
        GameObject manager = GameObject.Find("GameManager");
        manager.GetComponent<GameManager>().GameExplain();
        ballRd.isKinematic = false;
        ballRd.AddForce(dir);
        //transform.position = player.position + new Vector3(0, 0, 0.75f);
        //isBallInPlay = true;
    }

    //public void BonusBall()
    //{
    //    if(bonusBall < 2)
    //    {
    //        bonusBall++;
    //        //GameObject ball = GameObject.Find("BallGenerator");
    //        //ball.GetComponent<BallGenerator>().makeBall();
    //    }
    //}

}
