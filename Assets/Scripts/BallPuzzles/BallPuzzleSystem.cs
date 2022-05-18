using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BallPuzzleSystem : BallPuzzleCollision
{
    
    public event Action OnYellow = delegate { };
    public event Action OnBlue = delegate { };
    public event Action OnRed = delegate { };
    public event Action OnGreen = delegate { };
    public enum BoxCategory
    {
        Yellow, Red, Green, Blue
    }
    
    [SerializeField]
    private Text passwordText;
    [SerializeField]
    private int numPassword;
    

    public BoxCategory categoryBox;
    private bool OnTriggerYellow, OnTriggerRed, OnTriggerGreen, OnTriggerBlue;
    
    // Update is called once per frame
    void Update()
    {
        switch (categoryBox)
        {
            case BoxCategory.Yellow:
                YellowBox();
                break;

            case BoxCategory.Red:
                RedBox();
                break;

            case BoxCategory.Green:
                GreenBox();
                break;

            case BoxCategory.Blue:
                BlueBox();
                break;
        }
    }


    void YellowBox()
    {
        if(OnTriggerYellow)
        {
           passwordText.text = numPassword.ToString();

        }
        else
        {
            passwordText.text = "";
        }
    }

    void RedBox()
    {
        if (OnTriggerRed)
        {
            passwordText.text = numPassword.ToString();
        }
        else
        {
            passwordText.text = "";
        }
    }

    void GreenBox()
    {
        if (OnTriggerGreen)
        {
            passwordText.text = numPassword.ToString();
        }
        else
        {
            passwordText.text = "";
        }
    }
    void BlueBox()
    {
        if (OnTriggerBlue)
        {
            passwordText.text = numPassword.ToString();
        }
        else
        {
            passwordText.text = "";
        }
    }

    protected override void OnTrigger(Collider other)
    {
        if (other.CompareTag("Yellow"))
        {
            OnTriggerYellow = true;

        }

        else if (other.CompareTag("Red"))
        {
            OnTriggerRed = true;

        }

        else if (other.CompareTag("Green"))
        {
            OnTriggerGreen = true;

        }

        else if (other.CompareTag("Blue"))
        {
            OnTriggerBlue = true;

        }

    }

   
}
