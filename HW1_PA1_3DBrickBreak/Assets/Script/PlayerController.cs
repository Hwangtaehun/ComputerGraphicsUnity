using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) == true && this.transform.position.x >= 12.763f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow) == true && this.transform.position.x <= 21.158f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider Coll)
    {
        GameObject ball = GameObject.Find("BallGenerator");

        if (Coll.gameObject.CompareTag("LIFE"))
        {
            GameObject manager = GameObject.Find("GameManager");
            manager.GetComponent<GameManager>().UpdateLife(1);
            Destroy(Coll.gameObject);
        }
        else if(Coll.gameObject.CompareTag("ADD"))
        {
            ball.GetComponent<BallGenerator>().makeBall();
            Destroy(Coll.gameObject);
        }
        else if (Coll.gameObject.CompareTag("MINUS"))
        {
            GameObject manager = GameObject.Find("GameManager");
            manager.GetComponent<GameManager>().IncScore(-10);
            Destroy(Coll.gameObject);
        }
    }
}
