using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    float tkMvSpeed = 10.0f; // 탱크의 이동 속도
    float tkRotSpeed = 150.0f; // 탱크의 회전 속도
    string mvAxisName; // 이동 축의 이름 저장
    string rotAxisName; // 회전 축의 이름 저장
    public int playerNum = 1; // 플레이어 번호
    public Color tankColor; // tank 색상
    public ParticleSystem targetExplosion;
    int cnt = 0;

    void Start()
    {
        mvAxisName = "Vertical" + playerNum; // 플레이어 번호를 사용하여 입력키 부여
        rotAxisName = "Horizontal" + playerNum;

        // tank의 자식 오브젝트의 renderer(객체의 외관 담당) 찾기
        MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

        // 각 렌더러별로 컬러 지정하기
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = tankColor; // 선택한 색상 지정
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
