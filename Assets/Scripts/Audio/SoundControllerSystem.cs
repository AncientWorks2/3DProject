using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoundControllerSystem : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource soundSource;

    public abstract void SetSound();
}
