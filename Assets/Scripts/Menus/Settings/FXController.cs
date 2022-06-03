using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class FXController : MonoBehaviour
{
    public AudioMixer mixer;

    [SerializeField]
    private Text sliderValor;

    private float sValue;


    public void SetLevel(float sliderValue)
    {
        //Slider _slider = GetComponentInChildren<Slider>();

        PlayerPrefs.SetFloat("fxVolume", sliderValue);
        sValue = PlayerPrefs.GetFloat("fxVolume");

        mixer.SetFloat("FXVolume", Mathf.Log10(sValue) * 20);

        sValue = (sliderValue / gameObject.GetComponent<Slider>().maxValue) * 100;

        sliderValor.text = Mathf.Round(sValue).ToString() + "%";
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
