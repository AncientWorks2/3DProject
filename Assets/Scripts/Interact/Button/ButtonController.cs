using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : InteractManager
{
    [SerializeField]
    private Light light;
    [SerializeField]
    private int buttonNum;
    [SerializeField]
    private Material matOn;
    [SerializeField]
    private Material matOff;

    private bool isOn;

    private MeshRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
        isOn = true;

        UpdateButton();
        UpdateLight();
        UpdateButtonColor();
    }

    private void UpdateButton()
    {
        isOn = !isOn;
    }

    private void UpdateLight()
    {
        if (isOn)
        {
            light.color = Color.green;
        }
        else
        {
            light.color = Color.red;
        }
    }

    private void UpdateButtonColor()
    {
        if (isOn)
        {
            _renderer.material = matOn;
        }
        else
        {
            _renderer.material = matOff;
        }
    }

    public override string GetDescription()
    {
        if (isOn)
        {
            return "Presiona [E] para desativar la garra";
        }
        else
        {
            return "Presiona [E] para activar la garra";
        }
    }

    public override void Interact()
    {
        UpdateButton();
        UpdateLight();
        UpdateButtonColor();
    }   
    

    public bool ReturnInOn()
    {
        return isOn;
    }
}
