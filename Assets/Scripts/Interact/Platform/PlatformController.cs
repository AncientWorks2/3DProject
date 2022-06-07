using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : InteractManager
{  
    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void UpdateButton()
    {
        isOn = !isOn;
    }

    public override string GetDescription()
    {
        if (isOn)
        {
            return "Press [E] to restore the direction of the platforms";
        }
        else
        {
            return "Press [E] to chenge the direction of the platforms";
        }
    }

    public override void Interact()
    {
        UpdateButton();

        Level01Manager.handle = true;
    }

    public bool ReturnInOn()
    {
        return isOn;
    }
}
