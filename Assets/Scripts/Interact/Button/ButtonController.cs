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
        ButtonElection();
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

        Debug.Log(isOn);
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

    private void ButtonElection()
    {
        if (buttonNum == 1)
        {
            Level01Manager.button1 = isOn;
        }
        else if (buttonNum == 2)
        {
            Level01Manager.button2 = isOn;
        }
        else if (buttonNum == 3)
        {
            Level01Manager.button3 = isOn;
        }
        else if (buttonNum == 4)
        {
            Level01Manager.button4 = isOn;
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
        ButtonElection();
        UpdateLight();
        UpdateButtonColor();
    }   
    

    public bool ReturnInOn()
    {
        return isOn;
    }
}
