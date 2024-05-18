
using UnityEngine;

public class EnemyBossAtack : MonoBehaviour
{
    [SerializeField] private Transform HandFireBoss;
    [SerializeField] private GameObject bulletLeftBoss;
    [SerializeField] private GameObject bulletRightBoss;
    [SerializeField] private float fireRateBoss = 1.5f;
    [SerializeField] private float nextFireBoss = 0;
    private bool isAttacking = false;

    void Start()
    {

    }
    private void Update()
    {
        if(isAttacking==true) 
        {
          if (Time.time > nextFireBoss)
         {
            nextFireBoss = Time.time + fireRateBoss;

            if (this.transform.localScale == new Vector3(1, 1, 1))
            {

                Instantiate(bulletRightBoss, HandFireBoss.position + new Vector3(4, 1.7f, 0), HandFireBoss.rotation);

            }
            else if (this.transform.localScale == new Vector3(-1, 1, 1))
            {
                Instantiate(bulletLeftBoss, HandFireBoss.position + new Vector3(-4.25f, -2.515f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));

            }

         }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("player"))
        {


            isAttacking = true;



        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {


        if (collision.CompareTag("player"))
        {


            isAttacking = true;



        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {


            isAttacking = false;



        }
    }

}