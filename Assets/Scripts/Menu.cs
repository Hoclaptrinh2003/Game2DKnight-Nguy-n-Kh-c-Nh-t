
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Collections;


public class Menu : MonoBehaviour
{
    public GameObject shopMenu;
    public GameObject openVolume;
    public GameObject closeVolume;
    public GameObject auStop;
    public GameObject GAME_CONTROLS;
    PlayerCollisionHandling playHl;
    PlayerController player;

    private Audio Audiomusic;
    private void Awake()
    {
        Audiomusic = GameObject.FindGameObjectWithTag("audio").GetComponent<Audio>();
    }
    void Start()
    {
        playHl = FindObjectOfType<PlayerCollisionHandling>();
        player = FindObjectOfType<PlayerController>();
        GAME_CONTROLS.SetActive(true);
    }


    void Update()
    {
       
    }

    
    public void PlayGame() 
    {
        SceneManager.LoadScene("LEVEL1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenShop()
    {

        Time.timeScale = 0f;


        shopMenu.SetActive(true);

    }

    public void QuitGAME_CONTROLS()
    {




        GAME_CONTROLS.SetActive(false);

    }
    public void QuitShop()
    {

        Time.timeScale = 1f;


        shopMenu.SetActive(false);
    }

   

    public void buyHeart()
    {
      
        if (playHl.goldCoin >= 10)
        {
            if (playHl.blood < 400) 
            { 

            Audiomusic.playmusic(Audiomusic.BuyClip);
            playHl.goldCoin = playHl.goldCoin - 10;
            playHl.goldText.SetText(playHl.goldCoin.ToString());
            playHl.blood = playHl.blood + 10;
            playHl.heartText.SetText(playHl.blood.ToString());
            playHl.currentHeath = playHl.currentHeath + 10;
            playHl.playerHealthSlider.value = playHl.currentHeath;

            }
            if (playHl.blood >= 400)
            {
            playHl.blood = 400;
            playHl.heartText.SetText(playHl.blood.ToString());

            }

        }
    }

    public void buyApple()
    {
        if (playHl.goldCoin >= 15)
        {
            if (playHl.blood < 400)
            {
            Audiomusic.playmusic(Audiomusic.BuyClip);
            playHl.goldCoin = playHl.goldCoin - 15;
            playHl.goldText.SetText(playHl.goldCoin.ToString());
            playHl.blood = playHl.blood + 20;
            playHl.heartText.SetText(playHl.blood.ToString());
            playHl.currentHeath = playHl.currentHeath + 20;
            playHl.playerHealthSlider.value = playHl.currentHeath;
            }
            if (playHl.blood >= 400)
            {
                playHl.blood = 400;
                playHl.heartText.SetText(playHl.blood.ToString());

            }

        }
    }

    public void buyBullet()
    {
        if (playHl.goldCoin >= 5)
        {
            Audiomusic.playmusic(Audiomusic.BuyClip);
            playHl.goldCoin = playHl.goldCoin - 5;
            playHl.goldText.SetText(playHl.goldCoin.ToString());
            playHl.fire = playHl.fire + 1;
            playHl.fireText.SetText(playHl.fire.ToString());
            player.number_bullet = player.number_bullet+1;
        }
    }

    public void OpenVolume()
    {
        auStop.SetActive(false);

        openVolume.SetActive(false);
        closeVolume.SetActive(true);

    }

    public void CloseVolume()
    {
        auStop.SetActive(true);

        closeVolume.SetActive(false);
        openVolume.SetActive(true);
    }
}
