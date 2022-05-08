using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenOptions : MonoBehaviour
{
    [SerializeField]
    private Toggle _fullScreenToggle;

    private bool tValue;

    // Start is called before the first frame update
    void Start()
    {
        tValue = PlayerPrefs.GetInt("fullScreen")==1?true:false;

        _fullScreenToggle.isOn = tValue;

        SetFullScreen(tValue);
    }

    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;

        PlayerPrefs.SetInt("fullScreen", fullScreen?1:0);

    }
}
