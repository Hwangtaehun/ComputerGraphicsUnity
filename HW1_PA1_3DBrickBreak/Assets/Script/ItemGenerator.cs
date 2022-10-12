using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject lifeaddPrefab;
    public GameObject balladdPrefab;
    public GameObject scoreminusPrefab;
    public float span = 5.0f;
    private float time = 0.0f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > span)
        {
            time = 0;
            GameObject item;
            int dice = Random.Range(1, 9);
            float x = Random.Range(12.48f, 21.4f);
            //item = Instantiate(scoreminusPrefab);
            //item.transform.position = new Vector3(x, -4.341f, 98.38f);
            if (dice <= 3)
            {
                item = Instantiate(lifeaddPrefab);
                item.transform.position = new Vector3(x, -4.341f, 98.38f);
            }
            else if (dice > 3 && dice <= 6)
            {
                item = Instantiate(balladdPrefab);
                item.transform.position = new Vector3(x, -4.341f, 98.38f);
            }
            else if (dice > 6)
            {
                item = Instantiate(scoreminusPrefab);
                item.transform.position = new Vector3(x, -4.341f, 98.38f);
            }
        }
    }
}
