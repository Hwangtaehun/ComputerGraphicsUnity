using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 2.0f;
    Rigidbody playerRd;

    // Start is called before the first frame update
    void Start()
    {
        playerRd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerRd.AddForce(Vector3.left * speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerRd.AddForce(Vector3.right * speed);
        }
        else if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRd.AddForce(Vector3.forward * speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerRd.AddForce(Vector3.back * speed);
        }
        else if (Input.GetKey(KeyCode.Space) == true)
        {
            playerRd.AddForce(Vector3.up * speed);
        }
    }
}
