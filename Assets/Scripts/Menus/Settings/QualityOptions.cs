using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualityOptions : MonoBehaviour
{
    [SerializeField]
    private Dropdown quality;

    private int qualityVal;

    // Start is called before the first frame update
    void Start()
    {
        qualityVal = PlayerPrefs.GetInt("qualValue");

        quality.value = qualityVal;

        SetQuality(qualityVal);
    }

    public void SetQuality(int qualOption)
    {
        QualitySettings.SetQualityLevel(qualOption);

        PlayerPrefs.SetInt("qualValue", qualOption);
    }
}
