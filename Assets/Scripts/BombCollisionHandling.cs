
using UnityEngine;

public class BombCollisionHandling : MonoBehaviour
{
    Rigidbody2D rbBomb;
 
    public bool isGround;
    void Start()
    {
        rbBomb = GetComponent<Rigidbody2D>();
        rbBomb.isKinematic = true;
      

    }


    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player") )
        {
            rbBomb.isKinematic = false;


         
          
        }


        if (collision.CompareTag("Ground") || collision.CompareTag("flax") || collision.CompareTag("player"))
        {




            isGround = true;


        }

        
        
    }

    
}
