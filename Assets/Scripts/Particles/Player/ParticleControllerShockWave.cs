using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControllerShockWave : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private float delayTime;

    private ShockWaveSystem _shockWave;

    private void Awake()
    {
        _shockWave = GetComponent<ShockWaveSystem>();
    }

    private void OnEnable()
    {
        _shockWave.OnShock += SetParticles;
    }

    private void OnDisable()
    {
        _shockWave.OnShock -= SetParticles;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SetParticles()
    {
        StartCoroutine(Emission());
    }

    IEnumerator Emission()
    {
        particle.Play(true);

        yield return new WaitForSeconds(delayTime);

        particle.Stop(true);
    }
}
