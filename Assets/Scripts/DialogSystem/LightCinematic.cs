using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightCinematic : MonoBehaviour
{
    [SerializeField]
    private float timeFade;

    [SerializeField]
    private float minIntensisty;

    [SerializeField]
    private float maxIntesity;

    private Light2D lt;

    private bool lightOn;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light2D>();
        lt.intensity = -0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (lightOn)
        {
            lt.intensity += timeFade;

            if (lt.intensity > maxIntesity)
            {
                lightOn = false;
            }
        }
        else
        {
            lt.intensity -= timeFade;

            if (lt.intensity < minIntensisty)
            {
                lightOn = true;
            }
        }
    }
}
