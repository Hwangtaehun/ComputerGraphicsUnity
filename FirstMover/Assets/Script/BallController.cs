using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRd;
    public float speed = 100.0f;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        ballRd = GetComponent<Rigidbody>();

        startPos = new Vector3(0, 0, 0);
        ballRd.AddForce(-speed, 0.0f, speed * 0.7f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            ballRd.AddForce(Vector3.left * speed * 0.01f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            ballRd.AddForce(Vector3.right * speed * 0.01f);
        }
        else if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            ballRd.AddForce(Vector3.forward * speed * 0.01f);
        }
        else if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            ballRd.AddForce(Vector3.back * speed * 0.01f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
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
}
