using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void ResetGame()
    {
        if (PlayerPrefs.GetInt("checkpoint") == 0)
        {
            SceneManager.LoadSceneAsync("CinematicScene");
        }
        else
        {
            SceneManager.LoadSceneAsync("Gameplay");
        }
    }
}