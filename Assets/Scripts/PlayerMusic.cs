using System.Collections;
using UnityEngine;

public class PlayerMusic : MonoBehaviour
{
    private Audio Audiomusic;
    private PlayerController player;
    private bool isAttacking = false;
    private bool isMoving = false;
    private bool isCastAttacking = false;
    private bool isGrounded;

    void Awake()
    {
        Audiomusic = GameObject.FindGameObjectWithTag("audio").GetComponent<Audio>();
    }

    private void Start()
    {
        player = GetComponent<PlayerController>();
    }


    void Update()
    {
        if ((player.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || player.animator.GetCurrentAnimatorStateInfo(0).IsName("JumpAttack")) && !isAttacking)
        {
            Audiomusic.playmusic(Audiomusic.SwordClip);
            isAttacking = true; 
            StartCoroutine(ResetAttackSound());
        }




        if ((Input.GetAxis("Horizontal") != 0 ) && !isMoving && isGrounded)
        {

            Audiomusic.playmusic(Audiomusic.MoveClip);
            isMoving =true;
            StartCoroutine(ResetMoveSound());
        }




        if (Input.GetKey(KeyCode.F))
        {
            Audiomusic.playmusic(Audiomusic.FireClip);
            isCastAttacking = true;
            StartCoroutine(ResetCastAttackSound());
        }
    }

    IEnumerator ResetAttackSound()
    {
        yield return new WaitForSeconds(0.55f); 
        isAttacking = false;
   
    }

    IEnumerator ResetMoveSound()
    {
        yield return new WaitForSeconds(0.4f);
        isMoving = false;
    }

    IEnumerator ResetCastAttackSound()
    {
        yield return new WaitForSeconds(0.8f);
        isCastAttacking = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}