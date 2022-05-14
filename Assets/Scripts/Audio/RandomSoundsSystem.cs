using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundsSystem : MonoBehaviour
{
    [SerializeField]
    private float minWaitTime;
    [SerializeField]
    private float maxWaitTime;
    [SerializeField]
    private AudioClip[] sounds;
    [SerializeField]
    private AudioSource[] soundSource;

    private float waitTime;
    private int randomClip;
    private int randomSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            waitTime = Random.Range(minWaitTime, maxWaitTime);
            randomClip = Random.Range(0, sounds.Length);
            randomSource = Random.Range(0, soundSource.Length);


            soundSource[randomSource].PlayOneShot(sounds[randomClip]);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
