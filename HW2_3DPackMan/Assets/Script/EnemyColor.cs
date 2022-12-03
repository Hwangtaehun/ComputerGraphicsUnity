using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColor : MonoBehaviour
{
    public Color Enemycolor;

    void Start()
    {
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderers.Length; i++)
            renderers[i].material.color = Enemycolor;
    }
}
