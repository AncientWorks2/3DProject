using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensivityController : MonoBehaviour
{
    [SerializeField]
    private Text sliderValor;

    private float sValue;

    public void SetLevel(float sliderValue)
    {
        PlayerPrefs.SetFloat("mouseSense", sliderValue);

        sValue = (sliderValue / gameObject.GetComponent<Slider>().maxValue) * 100;

        sliderValor.text = Mathf.Round(sValue).ToString() + "%";
    }
}