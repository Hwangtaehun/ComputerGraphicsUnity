using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRd;
    private bool isBallInPlay = false;
    public float speed = 200.0f;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
        ballRd = GetComponent<Rigidbody>();
        startPos = transform.position;
        //startPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)==true && isBallInPlay == false)
        {
            GameObject manager = GameObject.Find("GameManager");
            manager.GetComponent<GameManager>().GameExplain();
            Time.timeScale = 1.0f;
            isBallInPlay = true;
            ballRd.isKinematic = false;
            ballRd.AddForce(speed, 0, speed);
        }
        else if(transform.position.z < 86)
        {
            Destroy(gameObject, 0.2f);
            isBallInPlay = false;
            GameObject manager = GameObject.Find("GameManager");
            manager.GetComponent<GameManager>().LoseBall();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
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

            GameObject manager = GameObject.Find("GameManager");
            manager.GetComponent<GameManager>().Break();
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
            if(this.transform.localScale.x >= 0.5f)
            {
                transform.localScale = this.transform.localScale * 0.9f;
            }
            //transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
    }
}
