using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ����
    public float rotationSpeed = 360f; // ȸ�� �ӵ� ����
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
        animator = GetComponentInChildren<Animator>(); // Animator ������Ʈ ������
    }

    void Update()
    {
        // �¿� ����Ű�� ���� ����Ű�� �������� �Ǻ�
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //����
        ySpeed += Physics.gravity.y * Time.deltaTime;
        if(characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = - 0.5f;
            animator.SetBool("Jumping", false);

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
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

        if (GameObject.FindGameObjectsWithTag("Dot").Length == 0)
        {
            GameObject enemy = GameObject.Find("Enemy");
            enemy.GetComponent<Enemy>().RunTure();
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
            GameObject manager = GameObject.Find("ScoreManager");
            manager.GetComponent<ScoreManager>().IncScore(5);
            Destroy(other.gameObject);
        }
        else if(other.tag =="DeadZone")
        {
            SceneManager.LoadScene("Failure");
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
}