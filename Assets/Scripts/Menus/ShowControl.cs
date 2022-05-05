using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowControl : MonoBehaviour
{
    [SerializeField]
    private GameObject gameSettingsUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnterControls()
    {
        gameSettingsUI.SetActive(true);
    }

    public void ExitControls()
    {
        gameSettingsUI.SetActive(false);
    }
}
