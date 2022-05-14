using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonPlatformController : InteractManager
{
    [SerializeField]
    private Light light;
    [SerializeField]
    private int buttonNum;

    public event Action<bool> OnIsOn = delegate { };
    public event Action OnIsOnConsole = delegate { };

    private bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        isOn = true;

        UpdateButton();
        UpdateLight();
        ButtonElection();
    }

    private void UpdateButton()
    {
        isOn = !isOn;

        OnIsOn(isOn);

        OnIsOnConsole();
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

    private void UpdateLight()
    {
        if (isOn)
        {
            light.color = Color.white;
        }
        else
        {
            light.color = Color.yellow;
        }
    }

    public override string GetDescription()
    {
        if (isOn)
        {
            return "Press [E] to desactive the engine " + buttonNum + " of the platforms";
        }
        else
        {
            return "Press [E] to activate the engine " + buttonNum + " of the platforms";
        }
    }

    public override void Interact()
    {
        UpdateButton();
        UpdateLight();
        ButtonElection();
    }
}
