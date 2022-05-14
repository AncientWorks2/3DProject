using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMoveSoundController : SoundControllerSystem
{
    private DoorController _doorContr;

    private void Awake()
    {
        _doorContr = GetComponent<DoorController>();
    }

    private void OnEnable()
    {
        _doorContr.OnInteract += SetSound;
    }

    private void OnDisable()
    {
        _doorContr.OnInteract -= SetSound;
    }

    public override void SetSound()
    {
        soundSource.PlayOneShot(sound);
    }
}
