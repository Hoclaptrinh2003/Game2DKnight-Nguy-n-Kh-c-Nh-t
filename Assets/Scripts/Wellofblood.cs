using UnityEngine;


public class Wellofblood : MonoBehaviour
{

    PlayerCollisionHandling playHL;




    void Start()
    {

        playHL = FindObjectOfType<PlayerCollisionHandling>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if (collision.CompareTag("player"))
        {
         
            if (playHL.blood < 400)
            {

                playHL.blood = playHL.blood + 1;
                playHL.heartText.SetText(playHL.blood.ToString());
                playHL.currentHeath = playHL.currentHeath + 1;
                playHL.playerHealthSlider.value = playHL.currentHeath;

            }

            if (playHL.blood >= 400)
            {

                playHL.blood = 400;
                playHL.heartText.SetText(playHL.blood.ToString());

            }

        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
      
        if (collision.CompareTag("player"))
        {
            if (playHL.blood < 400)
            {

                playHL.blood = playHL.blood + 10;
                playHL.heartText.SetText(playHL.blood.ToString());
                playHL.currentHeath = playHL.currentHeath + 10;
                playHL.playerHealthSlider.value = playHL.currentHeath;

            }

            if (playHL.blood >= 400)
            {
                playHL.blood = 400;
                playHL.heartText.SetText(playHL.blood.ToString());

            }
        }

    }

}
