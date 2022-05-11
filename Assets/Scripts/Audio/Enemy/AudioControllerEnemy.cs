using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerEnemy : MonoBehaviour
{
    [SerializeField]
    private AudioSource shotSound;
    [SerializeField]
    private AudioSource walkSound;

    private AudioSource _shotSound;
    private AudioSource _walkSound;
    private EnemyWarriorShootingSystem _enShot;
    private EnemyWarriorNavigation _enNav;

    private void Awake()
    {
        _shotSound = shotSound.GetComponent<AudioSource>();
        _walkSound = walkSound.GetComponent<AudioSource>();
        _enNav = GetComponent<EnemyWarriorNavigation>();
        _enShot = GetComponent<EnemyWarriorShootingSystem>();
    }

    private void OnEnable()
    {
        _enNav.OnWalk += SetWalk;
        _enShot.OnShot += SetShot;
    }

    private void OnDisable()
    {
        _enNav.OnWalk -= SetWalk;
        _enShot.OnShot -= SetShot;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SetWalk(bool action)
    {
        if (action)
        {
            _walkSound.Play();
        }
        else
        {
            _walkSound.Stop();
        }
    }

    private void SetShot(bool action)
    {
        if (action)
        {
            if (!_shotSound.isPlaying)
            {
                _shotSound.Play();
            }
        }
        else
        {
            _shotSound.Stop();
        }
    }
}
