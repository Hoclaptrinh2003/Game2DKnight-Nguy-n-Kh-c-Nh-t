
using UnityEngine;


public class Sword : MonoBehaviour
{
    PlayerController player;
    private CircleCollider2D cir2D;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        cir2D = GetComponentInChildren<CircleCollider2D>();
        cir2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position+ new Vector3(0.2f,-0.4f,0);
        this.transform.localScale = player.transform.localScale;    

        if (Input.GetMouseButtonDown(0) || player.animator.GetCurrentAnimatorStateInfo(0).IsName("JumpAttack"))
        {

            cir2D.enabled = true;
        } 
        else if (Input.GetMouseButton(0))
        {
            cir2D.enabled = true;
            player.transform.position += new Vector3(0.00001f, 0, 0);
        }
        else
        {

            cir2D.enabled = false;
        }
    }
}
