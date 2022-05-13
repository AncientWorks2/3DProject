using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemySoundController : SoundControllerSystem
{
    private EnemyWarriorShootingSystem _enShoot;

    private void Awake()
    {
        _enShoot = GetComponent<EnemyWarriorShootingSystem>();
    }

    private void OnEnable()
    {
        _enShoot.OnShot += SetSound;
    }

    private void OnDisable()
    {
        _enShoot.OnShot -= SetSound;
    }

    public override void SetSound()
    {
        soundSource.PlayOneShot(sound);
    }
}
