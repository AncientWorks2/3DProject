using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudioControllerSystem : MonoBehaviour
{
    public AudioSource audioSource;

    public abstract void SetAudio(bool action);
}
