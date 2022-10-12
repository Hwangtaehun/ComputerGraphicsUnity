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
        if(Coll.gameObject.CompareTag("LIFE"))
        {
            Debug.Log("생명");
            Destroy(Coll.gameObject);
        }
        else if(Coll.gameObject.CompareTag("ADD"))
        {
            Debug.Log("공추가");
            Destroy(Coll.gameObject);
        }
        else if (Coll.gameObject.CompareTag("SIZE"))
        {
            Debug.Log("공원래대로");
            Destroy(Coll.gameObject);
        }
    }
}
