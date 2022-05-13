using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerConsole : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip sound;
    [SerializeField]
    private AudioSource soundSource;

    private ButtonPlatformController _buttPlat;

    private void Awake()
    {
        _buttPlat = GetComponent<ButtonPlatformController>();
    }

    private void OnEnable()
    {
        _buttPlat.OnIsOn += SetAudio;
        _buttPlat.OnIsOn += SetSound;
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
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void SetSound(bool action)
    {
        soundSource.PlayOneShot(sound);
    }
}
