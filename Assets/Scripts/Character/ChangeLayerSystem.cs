using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayerSystem : MonoBehaviour
{
    private int initialLayer;
    private int newLayer;

    private bool changeLayer;

    private InputSystemKeyboard _input;

    private void Awake()
    {
        _input = GetComponent<InputSystemKeyboard>();

        initialLayer = LayerMask.NameToLayer("Player");
        newLayer = LayerMask.NameToLayer("Hide");
    }

    private void OnEnable()
    {
        _input.OnChangeLayer += SetNewLayer;
    }

    private void OnDisable()
    {
        _input.OnChangeLayer -= SetNewLayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SetNewLayer()
    {
        if (changeLayer)
        {
            gameObject.layer = newLayer;
            changeLayer = false;
        }
        else
        {
            gameObject.layer = initialLayer;
            changeLayer = true;
        }
    }
}
