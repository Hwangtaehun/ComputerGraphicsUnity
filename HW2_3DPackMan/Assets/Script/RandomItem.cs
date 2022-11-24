using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItem : MonoBehaviour
{
    public GameObject prefabScoreAdd;
    public GameObject prefabPlayerstop;
    public GameObject prefabEnemystop;
    public GameObject prefabPlayerspeed;
    public float interval = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateItem());
    }

    // Update is called once per frame
    IEnumerator CreateItem()
    {
        WaitForSeconds wait = new WaitForSeconds(interval);
        while(true)
        {
            int dice = Random.Range(1, 12);
            float x = Random.Range(-6.0f, 6.0f);
            float z = Random.Range(4.0f, -1.45f);
            transform.position = new Vector3(x, 0.45f, z);
            if (dice <= 3)
            {
                Instantiate(prefabScoreAdd, transform.position, transform.rotation);
            }
            else if (dice > 3 && dice <= 6)
            {
                Instantiate(prefabPlayerstop, transform.position, transform.rotation);
            }
            else if (dice > 6 && dice <= 9)
            {
                Instantiate(prefabEnemystop, transform.position, transform.rotation);
            }
            else
            {
                Instantiate(prefabPlayerspeed, transform.position, transform.rotation);
            }
            yield return wait;
            //Instantiate(prefabEnemystop, transform.position, transform.rotation);
            //yield return wait;
        }
    }
}
