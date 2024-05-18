using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform HandFireEnemy;
    [SerializeField] private GameObject bulletLeftEnemy;
    [SerializeField] private GameObject bulletRightEnemy;
    private float fireRateEnemy = 3f;
    private float nextFireEnemy = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) 
        { 
      
           if (this.transform.localScale == new Vector3(1, 1, 1) )
           {

            Instantiate(bulletRightEnemy, HandFireEnemy.position + new Vector3(4, 1.7f, 0), HandFireEnemy.rotation);

           }
           else if (this.transform.localScale == new Vector3(-1, 1, 1) )
           {
            Instantiate(bulletLeftEnemy, HandFireEnemy.position + new Vector3(-4.25f, -2.515f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));

           }
    
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {

            if (this.transform.localScale == new Vector3(1, 1, 1))
            {

                Instantiate(bulletRightEnemy, HandFireEnemy.position + new Vector3(4, 1.7f, 0), HandFireEnemy.rotation);

            }
            else if (this.transform.localScale == new Vector3(-1, 1, 1))
            {
                Instantiate(bulletLeftEnemy, HandFireEnemy.position + new Vector3(-4.25f, -2.515f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));

            }

        }
    }
}
