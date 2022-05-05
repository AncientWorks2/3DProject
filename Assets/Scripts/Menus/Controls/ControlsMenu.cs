using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject gameControlsUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnterControls()
    {
        gameControlsUI.SetActive(true);
    }

    public void ExitControls()
    {
        gameControlsUI.SetActive(false);
    }
}
