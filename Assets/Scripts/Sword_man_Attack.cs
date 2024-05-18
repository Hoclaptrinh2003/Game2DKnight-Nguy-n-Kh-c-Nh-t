using UnityEngine;


public class Sword_man_Attack : MonoBehaviour
{

    Animator Swordani;
    Rigidbody2D Swordrb;
    [SerializeField] private Transform HandFireEnemy;
    [SerializeField] private GameObject bulletLeftEnemy;
    [SerializeField]  GameObject bulletRightEnemy;
    private bool canAttack = true;



    void Start()
    {

        Swordani = GetComponent<Animator>();
        Swordrb = GetComponentInParent<Rigidbody2D>();
        canAttack = true;

    }


    private void RandomNumber()
    {

        if (!canAttack) return;
        canAttack = false;


        int randomNumber = Random.Range(1, 3);
        switch (randomNumber)
        {
            case 1:

                Swordani.SetBool("Attack", true);

                if (this.transform.localScale == new Vector3(1, 1, 1))
                {
                    Instantiate(bulletRightEnemy, HandFireEnemy.position + new Vector3(4, 1.7f, 0), HandFireEnemy.rotation);
                }
                else if (this.transform.localScale == new Vector3(-1, 1, 1))
                {
                    Instantiate(bulletLeftEnemy, HandFireEnemy.position + new Vector3(-4.25f, -2.515f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
                }
                break;
            case 2:
                Swordani.SetBool("Attack", true);
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                break;
        }


        Invoke("ResetAttack", 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("player") && canAttack == true)
        {
    
            RandomNumber();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("player") && canAttack==true)
        {
      
            RandomNumber();
        }
    }

   
 
    private void ResetAttack()
    {
        canAttack = true;
    }
}
