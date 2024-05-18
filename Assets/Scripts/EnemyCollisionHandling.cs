using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;



public class EnemyCollisionHandling : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 3f;
   

    Rigidbody2D Enemyrb;
    Animator Enemyani;

    [SerializeField] GameObject enemyGraphic;
   
    [SerializeField] float facingTime = 5f;
    [SerializeField] float nextFlip = 0f;
    private bool isFlipLeft;
    private bool isFlipRight;

    EnemyHealth enemyHl;
    void Awake()
    {
       Enemyrb = GetComponent<Rigidbody2D>();
       Enemyani = GetComponentInChildren<Animator>();
       enemyHl = GetComponentInChildren<EnemyHealth>();
    }


    void Update()
    {

        if (Time.time > nextFlip)
        {

            if (isFlipLeft == true || isFlipRight == true)
            {
                return;
            }

            nextFlip = Time.time + facingTime;
            FlipEnemyTime();
            
          
        }
    }

  
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("player")) 
        {
           if(other.transform.position.x < transform.position.x) 
            {
               isFlipLeft = true;
               FlipEnemyLeft();
             


            }
            else if ( other.transform.position.x > transform.position.x)
            {
               isFlipRight = true;
               FlipEnemyRight();

            }

     
        }
      
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("player"))
        {
            if (other.transform.position.x > transform.position.x)
            {
                Enemyrb.AddForce(new Vector2(1,0) * enemySpeed);
            }
            else Enemyrb.AddForce(new Vector2(-1, 0) * enemySpeed);
            Enemyani.SetBool("isRunning", true);
        }

        if (enemyHl.enemyBlood <= 0)
        {
            Enemyrb.velocity = Vector2.zero;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            Enemyrb.velocity = Vector2.zero;
            Enemyani.SetBool("isRunning", false);

        }
    }
    protected void FlipEnemyTime()
    {
        if(isFlipLeft==true || isFlipRight == true) { return; }
      
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }

    protected void FlipEnemyRight()
    {

   
        Vector3 theScaleRight = new Vector3(1,1,1);
  
        enemyGraphic.transform.localScale = theScaleRight;
    }

    protected void FlipEnemyLeft()
    {


        Vector3 theScaleLeft = new Vector3(-1, 1, 1);

        enemyGraphic.transform.localScale = theScaleLeft;
    }
}
