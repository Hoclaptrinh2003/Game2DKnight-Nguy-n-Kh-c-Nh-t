using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class Apple : MonoBehaviour
{
    Rigidbody2D rbApple;
    bool isGrounded;

    void Start()
    {
        rbApple = GetComponent<Rigidbody2D>();
        rbApple.isKinematic = true;
    }


    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("sword"))
        {


            rbApple.isKinematic = false;

        }

        if (isGrounded)
        {


            gameObject.tag = "apple";



        }

        if (collision.CompareTag("Ground"))
        {



            isGrounded = true;


        }





    }
}
