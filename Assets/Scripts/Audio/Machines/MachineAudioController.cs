using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineAudioController : AudioControllerSystem
{
    private ButtonPlatformController _buttPlat;

    private void Awake()
    {
        _buttPlat = GetComponent<ButtonPlatformController>();
    }

    private void OnEnable()
    {
        _buttPlat.OnIsOn += SetAudio;
    }
    private void OnDisable()
    {
        _buttPlat.OnIsOn -= SetAudio;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public override void SetAudio(bool action)
    {
        if (action)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
