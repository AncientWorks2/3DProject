using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveSoundController : SoundControllerSystem
{
    private ShockWaveSystem _shockWave;

    private void Awake()
    {
        _shockWave = GetComponent<ShockWaveSystem>();
    }

    private void OnEnable()
    {
        _shockWave.OnShock += SetSound;
    }

    private void OnDisable()
    {
        _shockWave.OnShock -= SetSound;
    }

    public override void SetSound()
    {
        soundSource.PlayOneShot(sound);
    }
}
