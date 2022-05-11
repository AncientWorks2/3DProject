using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerConsole : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;

    private AudioSource _audioSour;
    private ButtonPlatformController _buttPlat;

    private void Awake()
    {
        _audioSour = audio.GetComponent<AudioSource>();
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

    private void SetAudio(bool action)
    {
        if (action)
        {
            _audioSour.Play();
        }
        else
        {
            _audioSour.Stop();
        }
    }
}
