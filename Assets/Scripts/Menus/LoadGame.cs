using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadGame : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject loadingUI;
    public Image loadingProgress;

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartGame()
    {
        menuUI.SetActive(false);
        loadingUI.SetActive(true);

        scenesToLoad.Add(SceneManager.LoadSceneAsync("CinematicScene"));
        //scenesToLoad.Add(SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive));

        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        float totalProgress = 0;

        for (int i = 0; i < scenesToLoad.Count; i++)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                loadingProgress.fillAmount = totalProgress / scenesToLoad.Count;

                yield return null;
            }
        }
    }
}
