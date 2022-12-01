using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy1;
    private GameObject enemy2;
    private bool activelight = true;

    public GameObject light1;
    public GameObject light2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemy1 = GameObject.Find("Enemy");
        enemy2 = GameObject.Find("Enemy2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(enemy1.transform.position, player.transform.position) <= 3.0f)
        {
            if(activelight)
                light1.SetActive(true);
        }
        else
        {
            light1.SetActive(false);
        }

        if (Vector3.Distance(enemy2.transform.position, player.transform.position) <= 3.0f)
        {
            if (activelight)
                light2.SetActive(true);
        }
        else
        {
            light2.SetActive(false);
        }
    }

    public void DisenableLight()
    {
        activelight = false;
    }
}
