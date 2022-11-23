using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5.0f);
    }
}
