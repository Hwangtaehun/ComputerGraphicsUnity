using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    float tkMvSpeed = 10.0f; // ��ũ�� �̵� �ӵ�
    float tkRotSpeed = 150.0f; // ��ũ�� ȸ�� �ӵ�
    string mvAxisName; // �̵� ���� �̸� ����
    string rotAxisName; // ȸ�� ���� �̸� ����
    public int playerNum = 1; // �÷��̾� ��ȣ
    public Color tankColor; // tank ����
    public ParticleSystem targetExplosion;
    int cnt = 0;

    void Start()
    {
        mvAxisName = "Vertical" + playerNum; // �÷��̾� ��ȣ�� ����Ͽ� �Է�Ű �ο�
        rotAxisName = "Horizontal" + playerNum;

        // tank�� �ڽ� ������Ʈ�� renderer(��ü�� �ܰ� ���) ã��
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        // �� ���������� �÷� �����ϱ�
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = tankColor; // ������ ���� ����
        }
    }
    void Update()
    {
        float mv = Input.GetAxis(mvAxisName) * tkMvSpeed * Time.deltaTime;
        float rot = Input.GetAxis(rotAxisName) * tkRotSpeed * Time.deltaTime;
        transform.Translate(0, 0, mv);
        transform.Rotate(0, rot, 0);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "SHELL")
        {
            ParticleSystem fire = Instantiate(targetExplosion, transform.position, Quaternion.identity);
            fire.Play();
            cnt++;
            if(cnt > 1)
            {
                Destroy(gameObject);
                Destroy(fire.gameObject, 2.0f);
            }            
        }
        else if(coll.collider.tag == "DeadZone")
        {
            Destroy(gameObject);
        }
    }
}
