
using UnityEngine;

public class Sword_Man : MonoBehaviour
{
    [SerializeField] private float enemySword = 3f;


    Rigidbody2D Swordrb;
    Animator Swordani;

    [SerializeField] GameObject enemyGraphic;

  



    void Awake()
    {
        Swordrb = GetComponent<Rigidbody2D>();
        Swordani = GetComponentInChildren<Animator>();

    }


    void Update()
    {

    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            if (other.transform.position.x < transform.position.x)
            {
          
                FlipEnemyLeft();



            }
            else if (other.transform.position.x > transform.position.x)
            {
         
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
                Swordrb.AddForce(new Vector2(1, 0) * enemySword);
            }
            else Swordrb.AddForce(new Vector2(-1, 0) * enemySword);
            Swordani.SetBool("Run", true);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            Swordrb.velocity = Vector2.zero;
            Swordani.SetBool("Run", false);
            Swordani.SetBool("Attack", false);

        }
    }


    protected void FlipEnemyRight()
    {


        Vector3 theScaleRight = new Vector3(1, 1, 1);

        enemyGraphic.transform.localScale = theScaleRight;
    }

    protected void FlipEnemyLeft()
    {


        Vector3 theScaleLeft = new Vector3(-1, 1, 1);

        enemyGraphic.transform.localScale = theScaleLeft;
    }
}
