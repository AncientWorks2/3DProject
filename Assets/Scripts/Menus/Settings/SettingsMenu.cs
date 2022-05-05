using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{ 
    [SerializeField]
    private GameObject gameSettingsUI;

    // Start is called before the first frame update
    void Start()
    {
    }
    public void EnterSettings()
    {
        gameSettingsUI.SetActive(true);
    }

    public void ExitSettings()
    {
        gameSettingsUI.SetActive(false);
    }
}
