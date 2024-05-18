
using UnityEngine;

public class HeartMusic : MonoBehaviour
{
    private Audio Audiomusic;
    private void Awake()
    {
        Audiomusic = GameObject.FindGameObjectWithTag("audio").GetComponent<Audio>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            Audiomusic.playmusic(Audiomusic.HeartClip);
            Destroy(gameObject);
        }
    }


}
