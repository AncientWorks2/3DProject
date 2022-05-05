using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenOptions : MonoBehaviour
{
    private bool tValue;

    // Start is called before the first frame update
    void Start()
    {
        tValue = PlayerPrefs.GetInt("fullScreen")==1?true:false;

        SetFullScreen(tValue);
    }

    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;

        PlayerPrefs.SetInt("fullScreen", fullScreen?1:0);

    }
}
