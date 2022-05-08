using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOptions : MonoBehaviour
{

    Resolution[] resolutions;

    public Dropdown resolutionDrop;

    private int currentRes;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDrop.ClearOptions();

        List<string> options = new List<string>();

        currentRes = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
            {
                currentRes = i;

                PlayerPrefs.SetInt("resValue", currentRes);
            }

            
        }

        currentRes = PlayerPrefs.GetInt("resValue");

        resolutionDrop.AddOptions(options);
        resolutionDrop.value = currentRes;
        resolutionDrop.RefreshShownValue();

        SetResolution(currentRes);
    }

    public void SetResolution(int resValue)
    {
        Resolution resolution = resolutions[resValue];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        PlayerPrefs.SetInt("resValue", currentRes);
    }

    
}
