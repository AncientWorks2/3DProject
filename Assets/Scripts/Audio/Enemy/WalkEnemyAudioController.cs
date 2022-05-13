using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemyAudioController : AudioControllerSystem
{
    private EnemyWarriorNavigation _enNav;

    private void Awake()
    {
        _enNav = GetComponent<EnemyWarriorNavigation>();
    }

    private void OnEnable()
    {
        _enNav.OnWalk += SetAudio;
    }

    private void OnDisable()
    {
        _enNav.OnWalk -= SetAudio;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public override void SetAudio(bool action)
    {
        if (action)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
