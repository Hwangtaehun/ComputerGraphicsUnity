using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 지정
    public float rotationSpeed = 360f; // 회전 속도 지정
    public float jumpSpeed;

    float ySpeed;
    float originalStepOffset;
    bool slideing = false;
    bool attack = false;
    CharacterController characterController;
    Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        animator = GetComponentInChildren<Animator>(); // Animator 컴포넌트 가져옴
    }

    void Update()
    {
        GameObject sound = GameObject.Find("Sound");
        
        // 좌우 방향키와 상하 방향키를 눌렀는지 판별
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //점프
        ySpeed += Physics.gravity.y * Time.deltaTime;
        if(characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = - 0.5f;
            animator.SetBool("Jumping", false);

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
                sound.GetComponentInChildren<SoundEffect>().PlaySound("Jump");
                animator.SetBool("Jumping", true);
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }
        if (attack == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                sound.GetComponentInChildren<SoundEffect>().PlaySound("Slide");
                animator.SetBool("Sliding", true);
                slideing = true;
                Invoke("slideractionstop", 1.5f);
            }
        }

        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp( // 메소드를 조합해 플레이어의 방향 변환
            transform.forward,
            direction,
            rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
            );
            transform.LookAt(transform.position + forward);
        }
        // Move()를 이용해 이동, 충돌 처리, 속도 값 얻기 가능
        Vector3 velocity = direction * moveSpeed * Time.deltaTime;
        velocity.y = ySpeed * Time.deltaTime;

        characterController.Move(velocity);

        // Speed 파라미터를 통해 현재 속도의 크기(Character Controller)를 전달
        animator.SetFloat("Speed", characterController.velocity.magnitude);

        if (GameObject.FindGameObjectsWithTag("Dot").Length == 0)
        {
            GameObject enemy = GameObject.Find("Enemy");
            enemy.GetComponent<Enemy>().RunTure();
            stop();
            animator.SetBool("AttackTime", true);
            Invoke("attackactionstop", 3.0f);
            attack = true;
        }

        if(transform.position.y < 0)
        {
            SceneManager.LoadScene("Failure");
        }          
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Dot" )
        {
            GameObject manager = GameObject.Find("NumberManager");
            manager.GetComponent<NumberManager>().IncScore(5);
            Destroy(other.gameObject);
        }
        else if(other.tag =="DeadZone")
        {
            SceneManager.LoadScene("Failure");
        }
        else if(other.tag == "ScoreAdd")
        {
            GameObject manager = GameObject.Find("NumberManager");
            manager.GetComponent<NumberManager>().IncScore(10);
            Destroy(other.gameObject);
        }
        else if(other.tag == "PlayerStop")
        {
            stop();
            Destroy(other.gameObject);
        }
        else if(other.tag == "PlayerSpeed")
        {
            speedChange();
            Destroy(other.gameObject);
        }
        else if(other.tag == "EnemyStop")
        {
            GameObject enemy = GameObject.Find("Enemy");
            enemy.GetComponent<Enemy>().Stop();
            Destroy(other.gameObject);
        }

        if(attack == false)
        {
            if (other.tag == "Enemy")
            {
                SceneManager.LoadScene("Failure");
            }
        }
        else if(attack == true)
        {
            if (slideing == true)
            {
                if (other.tag == "Enemy")
                {
                    SceneManager.LoadScene("Success");
                }
            }
        }
    }

    public void attackactionstop()
    {
        animator.SetBool("AttackTime", false);
    }

    public void slideractionstop()
    {
        animator.SetBool("Sliding", false);
        slideing = false;
    }

    private void speedChange()
    {
        moveSpeed *= 2.0f;
        Invoke("speedOrigin", 5.0f);
    }

    private void speedOrigin()
    {
        moveSpeed = 5.0f;
    }

    private void stop()
    {
        moveSpeed = 0.0f;
        Invoke("speedOrigin", 5.0f);
    }
}
