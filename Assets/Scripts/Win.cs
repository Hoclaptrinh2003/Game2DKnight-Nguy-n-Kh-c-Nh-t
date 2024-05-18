using UnityEngine;
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("player"))
        {

            SceneManager.LoadScene("Win");

        }

    }

}
