using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : InteractManager
{  
    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        isOn = Level01Manager.handle;
    }

    private void UpdateButton()
    {
        isOn = !isOn;
    }

    private void UpdateButtonState()
    {
        Level01Manager.handle = isOn;
    }

    public override string GetDescription()
    {
        if (isOn)
        {
            return "Press [E] to restore the direction of the platforms";
        }
        else
        {
            return "Press [E] to change the direction of the platforms";
        }
    }

    public override void Interact()
    {
        UpdateButton();

        UpdateButtonState();
    }

    public bool ReturnInOn()
    {
        return isOn;
    }
}
