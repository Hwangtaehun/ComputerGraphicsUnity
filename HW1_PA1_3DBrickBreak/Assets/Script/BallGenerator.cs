using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) == true)
        {
            GameObject ball = Instantiate(ballPrefab, transform.position, transform.rotation);
            ball.GetComponent<BallController>().Update();
        }
    }
}
