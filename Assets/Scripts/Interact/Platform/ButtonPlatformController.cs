using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatformController : InteractManager
{
    [SerializeField]
    private Light light;
    [SerializeField]
    private int buttonNum;

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
            return "Presiona [E] para desativar motor " + buttonNum + " de la plataforma";
        }
        else
        {
            return "Presiona [E] para activar motor " + buttonNum + " de la plataforma";
        }
    }

    public override void Interact()
    {
        UpdateButton();
        UpdateLight();
        ButtonElection();
    }
}
