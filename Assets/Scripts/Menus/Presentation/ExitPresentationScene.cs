using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPresentationScene : MonoBehaviour
{
    private InputSystemKeyboard _inputSystem;

    private void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();
    }

    private void OnEnable()
    {
        _inputSystem.OnEnter += ChargeMainMenuScene;
    }

    private void OnDisable()
    {
        _inputSystem.OnEnter -= ChargeMainMenuScene;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ChargeMainMenuScene()
    {
        SceneManager.LoadScene("SceneMainMenu");
    }


}
