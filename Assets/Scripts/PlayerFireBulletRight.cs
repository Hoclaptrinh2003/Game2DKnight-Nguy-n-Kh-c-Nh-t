
using UnityEngine;

public class PlayerFireBulletRight : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 20f;
    private float CoefficientBullet = 100;
    [SerializeField] private float aliveTime = 1.7f;


    Rigidbody2D rb;
    
   
    void Awake()
    {


        rb = GetComponent<Rigidbody2D>();
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("player"))
        {
            Destroy(gameObject);
        }
    }

 

    void FixedUpdate()
    {
        
        rb.AddForce(new Vector2(1, 0) * bulletSpeed / CoefficientBullet, ForceMode2D.Impulse);

        Destroy(gameObject,aliveTime);

    }

  

}
