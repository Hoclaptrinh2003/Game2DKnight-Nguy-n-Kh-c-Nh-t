using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource musicAudio;
    public AudioSource vfxAudio;

    public AudioClip musicClip;
    public AudioClip CoinClip;
    public AudioClip SwordClip;
    public AudioClip MoveClip;
    public AudioClip FireClip;
    public AudioClip HeartClip;
    public AudioClip BombClip;
    public AudioClip BuyClip;

    void Awake()
    {
        musicAudio.clip = musicClip;
        musicAudio.Play();
    }

    private void Update()
    {
        if (!musicAudio.isPlaying)
        {
            musicAudio.Play();
        }
    }

    // Update is called once per frame
    public void playmusic(AudioClip sfxClip)
    {
        vfxAudio.clip = sfxClip;
        vfxAudio.PlayOneShot(sfxClip);

    }

    

}
