using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsSystem : MonoBehaviour
{
    [SerializeField]
    private int numKeypads;

    private KeypadController _keyPad;

    private void Awake()
    {
        _keyPad = GetComponent<KeypadController>();
    }

    private void OnEnable()
    {
        _keyPad.OnKeypad += LoadCredits;
    }

    private void OnDisable()
    {
        _keyPad.OnKeypad -= LoadCredits;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LoadCredits()
    {
        CreditsManager.kaypadValue += 1;

        Debug.Log("MeDejaEntrar");

        if (CreditsManager.kaypadValue == numKeypads)
        {
            SceneManager.LoadScene("CreditsScene");
        }
    }
}
