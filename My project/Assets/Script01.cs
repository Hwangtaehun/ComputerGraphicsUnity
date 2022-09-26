using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string str = "นÝบน";

        int count = 0;

        do
        {
            Debug.Log(str + count);
            count++;
        } while (count < 5);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
