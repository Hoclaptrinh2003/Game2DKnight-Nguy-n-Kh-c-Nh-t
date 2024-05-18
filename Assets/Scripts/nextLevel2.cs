
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel2 : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            SceneManager.LoadScene("LEVEL2");

        }
    }
}
