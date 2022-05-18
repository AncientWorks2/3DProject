using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel01 : MonoBehaviour
{
    private bool charged;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!charged)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            charged = true;
        }
    }
}
