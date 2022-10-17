using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private bool touch = false;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BALL"))
        {
            if (touch == true)
            {
                GameObject manager = GameObject.Find("GameManager");
                manager.GetComponent<GameManager>().IncScore(10);
                manager.GetComponent<GameManager>().UpdateBlockCnt(-1);
                Destroy(gameObject);
            }
            else
                touch = true;
        }
    }
}
