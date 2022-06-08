using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
    [SerializeField]
    private Text passwordText;
    [SerializeField]
    private int numPassword;
    [SerializeField]
    private int level;

    private bool isOn;

    private MeshRenderer _renderer;

    public event Action OnIsOn = delegate { };

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();

    }
    // Start is called before the first frame update
    void Start()
    {        
        //ButtonElection();

        if (PlayerPrefs.GetInt("checkpoint") == 0)
        {
            isOn = true;

            UpdateButton();
            ButtonElection();
            ButtonUpdate();
            UpdateLight();
            UpdateButtonColor();
            UpdateText();
        }
        else
        {
            ButtonUpdate();
            UpdateLight();
            UpdateButtonColor();
            UpdateText();
        }
    }

    private void UpdateButton()
    {
        isOn = !isOn;

        OnIsOn();
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

    private void UpdateText()
    {
        if (isOn)
        {
            passwordText.text = numPassword.ToString();
        }
        else
        {
            passwordText.text = "";
        }
    }

    private void ButtonElection()
    {
        if (level == 1)
        {
            if (buttonNum == 1)
            {
                Level01Manager.buttonPassword1 = isOn;
            }
            else if (buttonNum == 2)
            {
                Level01Manager.buttonPassword2 = isOn;
            }
            else if (buttonNum == 3)
            {
                Level01Manager.buttonPassword3 = isOn;
            }
            else if (buttonNum == 4)
            {
                Level01Manager.buttonPassword4 = isOn;
            }
        }

        Debug.Log("CHANGED BUTTON " + buttonNum + " " + isOn);

    }

    private void ButtonUpdate()
    {
        if (buttonNum == 1)
        {
            isOn = Level01Manager.buttonPassword1;
        }
        else if (buttonNum == 2)
        {
            isOn = Level01Manager.buttonPassword2;
        }
        else if (buttonNum == 3)
        {
            isOn = Level01Manager.buttonPassword3;
        }
        else if (buttonNum == 4)
        {
            isOn = Level01Manager.buttonPassword4;
        }

        Debug.Log("UPDATED BUTTON " + buttonNum + " " + isOn);
    }

    public override string GetDescription()
    {
        if (isOn)
        {
            return "Press [E] to desactivate the claw";
        }
        else
        {
            return "Press [E] to activate the claw";
        }
    }

    public override void Interact()
    {
        UpdateButton();
        UpdateLight();
        UpdateButtonColor();
        UpdateText();
        ButtonElection();
    }   
    

    public bool ReturnInOn()
    {
        return isOn;
    }
}
