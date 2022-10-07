using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject blockPrefab;

    // Update is called once per frame
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject block = Instantiate(blockPrefab);
            int px = Random.Range(13, 21);
            int pz = Random.Range(93, 95);
            block.transform.position = new Vector3(px, -4.3f, pz);
            GameObject manager = GameObject.Find("GameManager");
            manager.GetComponent<GameManager>().Count();
        }
    }
}
