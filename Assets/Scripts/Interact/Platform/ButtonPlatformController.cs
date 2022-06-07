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

        if (Level01Manager.newGame)
        {
            UpdateButton();
            ButtonElection();
            ButtonUpdate();
            UpdateLight();
            //ButtonElection();
        }
        else
        {
            UpdateParticle();
            ButtonUpdate();
            UpdateLight();
        }
    }

    private void UpdateButton()
    {
        isOn = !isOn;

        OnIsOn(isOn);

        OnIsOnConsole();
    }

    private void UpdateParticle()
    {
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

        Debug.Log("CHANGED PLAT " + buttonNum + " " + isOn);
    }

    private void ButtonUpdate()
    {
        if (buttonNum == 1)
        {
            isOn = Level01Manager.button1;
        }
        else if (buttonNum == 2)
        {
            isOn = Level01Manager.button2;
        }
        else if (buttonNum == 3)
        {
            isOn = Level01Manager.button3;
        }
        else if (buttonNum == 4)
        {
            isOn = Level01Manager.button4;
        }

        Debug.Log("UPDATED PLAT " + buttonNum + " " + isOn);
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
