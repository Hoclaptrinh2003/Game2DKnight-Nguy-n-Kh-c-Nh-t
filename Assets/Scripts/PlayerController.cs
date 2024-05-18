using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rbBody;
    public Animator animator;


    public int number_bullet = 80;

    private Vector3 inputMove;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jump = 30f;




    [SerializeField] private Transform HandFire;
    [SerializeField] private GameObject bulletLeft;
    [SerializeField] private GameObject bulletRight;

    private float fireRate = 0.075f;
    private float nextFire = 0;


    private bool isGrounded;
    private bool isAttacking = false;


    private Sword sw;

    PlayerCollisionHandling pc;
    void Start()
    {
        rbBody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();


       
        pc = GetComponent<PlayerCollisionHandling>();
    }

    private void Update()
    {

        HandleInput();
    
    }

    private void FixedUpdate()
    {
        FireBullet();

        Move();

        JumpAttack();

    }




    private void Move()
    {

        float CoefficientMove = 1f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            CoefficientMove = 0.6f;
        }


        inputMove.x = Input.GetAxis("Horizontal");
        transform.position += inputMove / CoefficientMove * speed * Time.deltaTime;


        if (inputMove.x == 0)
        {
            animator.SetBool("Walk", false);
        }
        else if (inputMove.x < 0)
        {
            animator.SetBool("Walk", true);
            this.transform.localScale = new Vector3(-1, 1, 0);
        }
        else if (inputMove.x > 0)
        {
            animator.SetBool("Walk", true);
            this.transform.localScale = new Vector3(1, 1, 0);
        }


        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack", true);

        }


        animator.SetBool("Cast", Input.GetKey(KeyCode.F));


    }

    private void JumpAttack()
    {

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {

            Vector2 Jumping = new Vector2(rbBody.velocity.x, jump);
            rbBody.velocity = Jumping;
            animator.SetBool("JumpAttack", true);
            isGrounded = false;

        }


        if (isGrounded == true)
        {

            animator.SetBool("JumpAttack", false);

        }


        animator.SetBool("Cast", Input.GetKey(KeyCode.F));


    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartAttack();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopAttack();
        }
    }



    protected void FireBullet()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;


            if (Input.GetKey(KeyCode.F))
            {
                pc.checkFire();
                number_bullet = Mathf.Clamp(number_bullet,0, number_bullet);
                if (number_bullet == 0) { return;}
                number_bullet--;
                if (number_bullet >= 0)
                {

                    if (this.transform.localScale == new Vector3(1, 1, 0) || this.transform.localScale == new Vector3(1, 1, 1))
                    {

                        Instantiate(bulletRight, HandFire.position + new Vector3(4, 1.7f, 0), HandFire.rotation);

                    }
                    else if (this.transform.localScale == new Vector3(-1, 1, 0) || this.transform.localScale == new Vector3(1, 1, 1))
                    {
                        Instantiate(bulletLeft, HandFire.position + new Vector3(-4.25f, -2.515f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));

                    }

                }

            }
        }
    }

    void StartAttack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            animator.SetBool("Attack", true);
        }
    }

    void StopAttack()
    {
        if (isAttacking)
        {
            isAttacking = false;

            animator.SetBool("Attack", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

  
    
}
