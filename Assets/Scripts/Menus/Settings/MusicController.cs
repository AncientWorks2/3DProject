using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class MusicController : MonoBehaviour
{
    public AudioMixer mixer;

    private float sValue;


    public void SetLevel (float sliderValue)
    {
        //Slider _slider = GetComponentInChildren<Slider>();

        PlayerPrefs.SetFloat("musicVolume", sliderValue);
        sValue = PlayerPrefs.GetFloat("musicVolume");

        mixer.SetFloat("MusicVol", Mathf.Log10(sValue) * 20);
    }

    public void Update()
    {

    }
}