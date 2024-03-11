using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("----------Audio Source----------")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource SFX;

    [Header("----------Audio Clip----------")]
    public AudioClip BackGround;
    public AudioClip Jump;
    public AudioClip Collect;

    void Start()
    {
        music.clip = BackGround;
        music.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
