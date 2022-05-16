using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicController : MonoBehaviour
{
    [SerializeField]
    private string presentationSceneName;
    [SerializeField]
    private string mainMenuSceneName;

    private Scene scene;
    private AudioSource _music;

    private void Awake()
    {
        _music = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();

        if (scene.name == presentationSceneName || scene.name == mainMenuSceneName)
        {
            if (!_music.isPlaying)
            {
                _music.Play();
            }
        }
        else
        {
            _music.Stop();
        }
    }
}
