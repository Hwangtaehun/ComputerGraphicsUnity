using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public Rigidbody prefabShell;
    public Transform fireTransform;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    void Fire()
    {
        Rigidbody shellInstance = Instantiate(prefabShell, fireTransform.position,
        fireTransform.rotation) as Rigidbody;
        // Shell에 속도 부여: 탱크의 정면 방향의 힘으로 설정
        shellInstance.velocity = 20.0f * fireTransform.forward;
    }

}
