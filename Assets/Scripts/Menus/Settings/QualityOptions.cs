using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityOptions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetQuality(int qualOption)
    {
        QualitySettings.SetQualityLevel(qualOption);
    }
}
