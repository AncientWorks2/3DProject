using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControllerConsole : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;

    private ParticleSystem _partSys;
    private ButtonPlatformController _buttPlat;

    private void Awake()
    {
        _partSys = particle.GetComponent<ParticleSystem>();
        _buttPlat = GetComponent<ButtonPlatformController>();
    }

    private void OnEnable()
    {
        _buttPlat.OnIsOn += SetParticles;
    }
    private void OnDisable()
    {
        _buttPlat.OnIsOn -= SetParticles;
    }

    private void Start()
    {
        
    }

    private void SetParticles(bool action)
    {
        if (action)
        {
            _partSys.Play(true);
        }
        else
        {
            _partSys.Stop(true);
        }
    }


}
