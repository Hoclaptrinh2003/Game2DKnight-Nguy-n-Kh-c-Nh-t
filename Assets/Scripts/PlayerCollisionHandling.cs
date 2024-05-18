using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerCollisionHandling : MonoBehaviour
{
                     public int blood = 400;
    [SerializeField] public int goldCoin = 0;
                     public float currentHeath = 0;
                     public int fire = 80;
    [SerializeField] public TextMeshProUGUI heartText;
    [SerializeField] public TextMeshProUGUI goldText;
    [SerializeField] public TextMeshProUGUI fireText;





    [SerializeField] public Slider playerHealthSlider;

    PlayerController player;
    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }


    private void Start()
    {
      

        heartText.SetText(blood.ToString());
        goldText.SetText(goldCoin.ToString());
        fireText.SetText(fire.ToString());


        currentHeath = blood;
        playerHealthSlider.maxValue = blood;
        playerHealthSlider.value = blood;

    }

    private void Update()
    {
        if (blood<=0)
        {
            LossGame();
        }

     
    }

   

    public void checkFire()
    {
        if (Input.GetKey(KeyCode.F))
        {
            fire--;
            fireText.SetText(fire.ToString());
            if(fire<=0)
            {
                fire = 0;
                fireText.SetText(fire.ToString());

            }
       
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       


        if (collision.CompareTag("flax"))
        {

            currentHeath--;
            playerHealthSlider.value = currentHeath;

            blood--;
            heartText.SetText(blood.ToString());

           
        }

        if (collision.CompareTag("Bullet"))
        {

            fire = fire + 5;
            fireText.SetText(fire.ToString());
            player.number_bullet = player.number_bullet+5;
            Destroy(collision.gameObject);
         

        }

        if (collision.CompareTag("bomb"))
        {

            currentHeath = currentHeath -20;
            playerHealthSlider.value = currentHeath;

            blood = blood -20;
            heartText.SetText(blood.ToString());


        }

        if (collision.CompareTag("Coin"))
        {

            goldCoin++;
            goldText.SetText(goldCoin.ToString());
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("goldenBarrel"))
        {

            goldCoin = goldCoin+10;
            goldText.SetText(goldCoin.ToString());
            Destroy(collision.gameObject);
          
        }

       
        if (collision.CompareTag("enemy"))
        {

            currentHeath = currentHeath-1;
            playerHealthSlider.value = currentHeath;

            blood = blood-1;
            heartText.SetText(blood.ToString());

        }
            

        if (collision.CompareTag("heart"))
        {

            currentHeath = currentHeath + 5;
            playerHealthSlider.value = currentHeath;
  
            if (blood < 400)
            {
                blood = blood + 5;
                heartText.SetText(blood.ToString());

            }

            if (blood>400)
            {
                blood = 400;
                heartText.SetText(blood.ToString());

            }
           


            Destroy(collision.gameObject);
           

        }

        if (collision.CompareTag("Fire"))
        {

            currentHeath = currentHeath - 1;
            playerHealthSlider.value = currentHeath;

            blood = blood - 1;
            heartText.SetText(blood.ToString());


        }
       
        if (collision.CompareTag("apple"))
        {
           
            currentHeath = currentHeath + 10;
            playerHealthSlider.value = currentHeath;

            if (blood < 400)
                {

                    Destroy(collision.gameObject);
                    blood = blood + 10;
                    heartText.SetText(blood.ToString());


                }

            if (blood > 400)
                {

                    blood = 400;
                    heartText.SetText(blood.ToString());
                    Destroy(collision.gameObject);

 
                }
            



        }




    }


  
    public void LossGame()
    {

    SceneManager.LoadScene("Menu");
       
    }

}
