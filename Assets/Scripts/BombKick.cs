using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombKick : MonoBehaviour
{

    Animator aniBomb;
    public bool isGround;

    void Start()
    {
        
        aniBomb = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
       if(isGround == true)
        {
            aniBomb.SetBool("isExplosion", true);
            Destroy(gameObject,0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       


        if (collision.CompareTag("Ground") || collision.CompareTag("flax") || collision.CompareTag("player"))
        {



           // gameObject.tag = "bomb";
            isGround = true;


        }



    }
}
