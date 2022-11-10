using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    float tkMvSpeed = 10.0f; // ��ũ�� �̵� �ӵ�
    float tkRotSpeed = 150.0f; // ��ũ�� ȸ�� �ӵ�
    void Update()
    {
        //float mv = Input.GetAxis("Vertical1") * tkMvSpeed * Time.deltaTime; // ������
        //float rot = Input.GetAxis("Horizontal1") * tkRotSpeed * Time.deltaTime; // ȸ��
        float mv = Input.GetAxis("Vertical") * tkMvSpeed * Time.deltaTime;
        float rot = Input.GetAxis("Horizontal") * tkRotSpeed * Time.deltaTime;
        transform.Translate(0, 0, mv);
        transform.Rotate(0, rot, 0);
    }
}
