using System.Collections;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using System.Collections.Generic; 



public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float enemyBlood = 50;
                     float maxEnemyBlood;
                     float currentHeathEnemy = 0;
    [SerializeField] private Slider enemyHealthSlider;

 
    Animator ani;


    public List<GameObject> CoinEnemy;




    void Start()
    {
        maxEnemyBlood = enemyBlood;
        ani = GetComponent<Animator>();

        currentHeathEnemy = enemyBlood;
        enemyHealthSlider.maxValue = enemyBlood;
        enemyHealthSlider.value = enemyBlood;

        foreach (GameObject gameOj in CoinEnemy)
        {
            gameOj.SetActive(false);
        }
        
    }

    
    void Update()
    {
        if (enemyBlood <= 0)
        {
            Destroy(enemyHealthSlider.gameObject,1f);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("fire"))
        {
            enemyBlood = enemyBlood - 4;
            currentHeathEnemy = currentHeathEnemy - 4;
            enemyHealthSlider.value = currentHeathEnemy;
            
        }

        if (collision.CompareTag("sword"))
        {
            enemyBlood = enemyBlood - 3f;
            currentHeathEnemy = currentHeathEnemy - 3f;
            enemyHealthSlider.value = currentHeathEnemy;

        }

        if (enemyBlood <= 0)
        {
            MakeDie();
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
       

        if (collision.CompareTag("sword"))
        {
            enemyBlood = enemyBlood - 0.5f;
            currentHeathEnemy = currentHeathEnemy - 0.5f;
            enemyHealthSlider.value = currentHeathEnemy;

        }

        if (enemyBlood <= 0)
        {
            MakeDie();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("sword"))
        {

            enemyBlood = enemyBlood - 0;
            currentHeathEnemy = currentHeathEnemy - 0;
            enemyHealthSlider.value = currentHeathEnemy;

        }
    }
    private void MakeDie()
    {
        ani.SetBool("Dead",true);
        Destroy(gameObject,1.5f);
        foreach (GameObject gameOj in CoinEnemy)
        {
            gameOj.SetActive(true);
        }
       

    }


}
