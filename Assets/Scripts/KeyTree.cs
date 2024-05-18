using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class KeyTree : MonoBehaviour
{
    Rigidbody2D rbTree;
    void Start()
    {
        rbTree = GetComponent<Rigidbody2D>();
        rbTree.isKinematic = true;
    }

    
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            rbTree.isKinematic = false;
  
            this.transform.localScale = new Vector3(2, 2, 2);


        }
    }
}
