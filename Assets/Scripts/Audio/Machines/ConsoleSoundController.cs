using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleSoundController : SoundControllerSystem
{
    private ButtonPlatformController _buttCons;

    private void Awake()
    {
        _buttCons = GetComponent<ButtonPlatformController>();
    }

    private void OnEnable()
    {
        _buttCons.OnIsOnConsole += SetSound;
    }

    private void OnDisable()
    {
        _buttCons.OnIsOnConsole -= SetSound;
    }

    public override void SetSound()
    {
        soundSource.PlayOneShot(sound);
    }
}
