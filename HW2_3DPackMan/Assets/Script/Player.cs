using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ����
    public float rotationSpeed = 360f; // ȸ�� �ӵ� ����
    public float jumpSpeed;

    CharacterController characterController;
    Animator animator;
    float ySpeed;
    float originalStepOffset;
    bool working = true;
    bool slideing = false;
    bool attack = false;
    bool input = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
        animator = GetComponentInChildren<Animator>(); // Animator ������Ʈ ������
    }

    void Update()
    {
        GameObject sound = GameObject.Find("Sound");
        
        if (input == true)
        {
            // �¿� ����Ű�� ���� ����Ű�� �������� �Ǻ�
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            //����
            ySpeed += Physics.gravity.y * Time.deltaTime;
            if (characterController.isGrounded)
            {
                characterController.stepOffset = originalStepOffset;
                ySpeed = -0.5f;
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
                Vector3 forward = Vector3.Slerp( // �޼ҵ带 ������ �÷��̾��� ���� ��ȯ
                transform.forward,
                direction,
                rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
                );
                transform.LookAt(transform.position + forward);
            }
            // Move()�� �̿��� �̵�, �浹 ó��, �ӵ� �� ��� ����
            Vector3 velocity = direction * moveSpeed * Time.deltaTime;
            velocity.y = ySpeed * Time.deltaTime;

            characterController.Move(velocity);

            // Speed �Ķ���͸� ���� ���� �ӵ��� ũ��(Character Controller)�� ����
            animator.SetFloat("Speed", characterController.velocity.magnitude);

            if (transform.position.y < 0)
            {
                SceneManager.LoadScene("Failure");
            }
        }

        if (working == true)
        {
            if (GameObject.FindGameObjectsWithTag("Dot").Length == 0)
            {
                input = false;
                GameObject enemy = GameObject.Find("Enemy");
                enemy.GetComponent<Enemy>().RunTure();
                GameObject enemy2 = GameObject.Find("Enemy2");
                enemy2.GetComponent<Enemy>().RunTure();
                animator.SetBool("AttackTime", true);
                Invoke("attackactionstop", 2.0f);
                attack = true;
                working = false;
            }
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
            moveSpeed = 0.0f;
            jumpSpeed = 0.0f;
            Destroy(other.gameObject);
            Invoke("speedOrigin", 2.5f);
        }
        else if(other.tag == "PlayerSpeed")
        {
            moveSpeed = 2.5f;
            Destroy(other.gameObject);
            Invoke("speedOrigin", 5.0f);
        }
        else if(other.tag == "EnemyStop")
        {
            GameObject enemy = GameObject.Find("Enemy");
            enemy.GetComponent<Enemy>().Stop();
            GameObject enemy2 = GameObject.Find("Enemy2");
            enemy2.GetComponent<Enemy>().Stop();
            Destroy(other.gameObject);
        }

        if (attack == false)
        {
            if (other.tag == "Enemy")
            {
                SceneManager.LoadScene("Failure");
            }
        }
        else if (attack == true)
        {
            if (slideing == true)
            {
                if (other.tag == "Enemy")
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }

    public void attackactionstop()
    {
        animator.SetBool("AttackTime", false);
        input = true;
    }

    public void slideractionstop()
    {
        animator.SetBool("Sliding", false);
        slideing = false;
    }

    private void speedOrigin()
    {
        moveSpeed = 5.0f;
        jumpSpeed = 5.0f;
    }
}
