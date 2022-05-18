using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBigDoor : InteractManager
{
    [SerializeField]
    private Light light;

    public DoorController door;
    private bool isOpen;
    private bool isOn;

    // Start is called before the first frame update
    void Start()
    {
        UpdateLight();
    }
    void OpeningDoor()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            door.isOpeningSlide = true;
        }
        else
        {
            door.isOpeningSlide = false;
        }
    }
    void UpdateLight()
    {
        isOn = !isOn;
        if (isOn)
        {
            light.color = Color.green;
        }
        else
        {
            light.color = Color.red;
        }
    }
    public override string GetDescription()
    {
        if (isOpen) return " Press [E] to close the door";
        return "Press [E] to open the door";


    }

    public override void Interact()
    {
        OpeningDoor();
        UpdateLight();
    }

}