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
            return "Presiona [E] para cambiar direccion de la plataforma";
        }
        else
        {
            return "Presiona [E] para cambiar direccion de la plataforma";
        }
    }

    public override void Interact()
    {
        UpdateButton();
    }

    public bool ReturnInOn()
    {
        return isOn;
    }
}
