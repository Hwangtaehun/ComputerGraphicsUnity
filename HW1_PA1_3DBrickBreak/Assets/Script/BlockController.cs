using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BALL"))
        {
            GameObject manager = GameObject.Find("GameManager");
            manager.GetComponent<GameManager>().IncScore();
            Destroy(gameObject, 0.2f);
        }
    }
}
