using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        UpdateText();
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
        UpdateText();
    }   
    

    public bool ReturnInOn()
    {
        return isOn;
    }
}
