using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OpotionScreen : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SFXSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("musicSettings"))
        {
            LoadMusicVolume();
        }
        else
        {
            ChangeMusicVolume();
            ChangeSFXVolume();
        }
        gameObject.SetActive(false);
        
    }

    public void ChangeMusicVolume()
    {
        float Volume = MusicSlider.value;
        Mixer.SetFloat("Music",Volume);
        PlayerPrefs.SetFloat("musicSettings", Volume);
    }

        public void ChangeSFXVolume()
    {
        float Volume = SFXSlider.value;
        Mixer.SetFloat("SFX", Mathf.Log10(Volume)*20);
        PlayerPrefs.SetFloat("SFXSettings", Volume);
    }

    private void LoadMusicVolume()
    {
        MusicSlider.value = PlayerPrefs.GetFloat("musicSettings");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXSettings");
        ChangeMusicVolume();
        ChangeSFXVolume();
    }
}
