using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOptions : MonoBehaviour
{

    Resolution[] resolutions;

    public Dropdown resolutionDrop;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDrop.ClearOptions();

        List<string> options = new List<string>();

        int currentRes = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }
        }

        resolutionDrop.AddOptions(options);
        resolutionDrop.value = currentRes;
        resolutionDrop.RefreshShownValue();
    }

    public void SetResolution(int resValue)
    {
        Resolution resolution = resolutions[resValue];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    
}
