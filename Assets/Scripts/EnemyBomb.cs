
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    EnemyHealth enemyHealth;
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            Destroy(gameObject);

            foreach (GameObject gameOj in enemyHealth.CoinEnemy)
            {
                gameOj.SetActive(true);
            }
        }
    }
}
