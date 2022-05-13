using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonSoundController : SoundControllerSystem
{
    private ButtonController _buttContr;

    private void Awake()
    {
        _buttContr = GetComponent<ButtonController>();
    }

    private void OnEnable()
    {
        _buttContr.OnIsOn += SetSound;
    }

    private void OnDisable()
    {
        _buttContr.OnIsOn -= SetSound;
    }

    public override void SetSound()
    {
        soundSource.PlayOneShot(sound);
    }
}
