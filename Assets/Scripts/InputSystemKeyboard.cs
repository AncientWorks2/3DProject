using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class InputSystemKeyboard : MonoBehaviour
{ 
    public float axHor { get; private set; } //Horizontal axis keyboard
    public float axVer { get; private set; } //Vertical axis keyboard
    public float moHor { get; private set; } //Horizontal axis mouse
    public float moVer { get; private set; } //Vertical axis mouse
    public float mousePosX { get; private set; } //X position mouse
    public float mousePosY { get; private set; } //Y position mouse


    public event Action OnPause = delegate { };
    public event Action OnJump = delegate { };
    public event Action OnCrouch = delegate { };
    public event Action<bool> OnRun = delegate { };
    public event Action<bool> OnInteract = delegate { };
    public event Action OnShock = delegate { };
    //Objects
    public event Action<bool> OnPick = delegate { };
    public event Action OnThrow = delegate { };
    //Menu
    public event Action OnEnter = delegate { };

    //KeyPad
    public event Action<bool> OnKeyPad = delegate { };


    //GoodKeys events
    public event Action OnInvencible = delegate { };
    public event Action OnFullStamina = delegate { };
    public event Action OnChangeLayer = delegate { };

    // Update is called once per frame
    private void Update()
    {
        if (!PauseManager.pauseMode)
        {
            //Keyboard
            axHor = Input.GetAxis("Horizontal");
            axVer = Input.GetAxis("Vertical");
            //Mouse
            moHor = Input.GetAxisRaw("Mouse X");
            moVer = Input.GetAxisRaw("Mouse Y");
            //Mouse position (to menu dinamic image)
            mousePosX = Input.mousePosition.x;
            mousePosY = Input.mousePosition.y;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnEnter();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPause(); //Cuando se pulsa la tecla "Esc" el juego se pausa
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJump();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                OnCrouch();
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                OnRun(true);
            }
            else
            {
                OnRun(false);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                OnShock();
            }

            //InteractButton
            if (Input.GetKeyDown(KeyCode.E)) { OnInteract(true); }
            else { OnInteract(false); }

            //PickUpKey
            if (Input.GetMouseButtonDown(0)) { OnPick(true); OnKeyPad(true); }
            else { OnPick(false); OnKeyPad(false); }

            //ThrowObjectKey
            if (Input.GetMouseButtonDown(1)) { OnThrow(); }
        }
        //God Keys
        //Invencible
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            OnInvencible();
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            OnFullStamina();
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            OnChangeLayer();
        }
    }

    public float ReturnAxHor()
    {
        return axHor;
    }

    public float ReturnAxVer()
    {
        return axVer;
    }
}