using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    float tkMvSpeed = 10.0f; // 탱크의 이동 속도
    float tkRotSpeed = 150.0f; // 탱크의 회전 속도
    void Update()
    {
        //float mv = Input.GetAxis("Vertical1") * tkMvSpeed * Time.deltaTime; // 전후진
        //float rot = Input.GetAxis("Horizontal1") * tkRotSpeed * Time.deltaTime; // 회전
        float mv = Input.GetAxis("Vertical") * tkMvSpeed * Time.deltaTime;
        float rot = Input.GetAxis("Horizontal") * tkRotSpeed * Time.deltaTime;
        transform.Translate(0, 0, mv);
        transform.Rotate(0, rot, 0);
    }
}
