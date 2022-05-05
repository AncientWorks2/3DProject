using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField]
    private Slider _sliderMusic;

    [SerializeField]
    private Slider _sliderFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        _sliderMusic.value = PlayerPrefs.GetFloat("musicVolume");

        _sliderFX.value = PlayerPrefs.GetFloat("fxVolume");
    }
}
