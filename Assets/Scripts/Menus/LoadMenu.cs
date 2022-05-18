using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadsMenu()
    {
        //System.GC.Collect();

        SceneManager.LoadScene("SceneMainMenu");

        Time.timeScale = 1f;

        PauseManager.pauseMode = false;
    }
}
