using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaSystem : MonoBehaviour
{
    [SerializeField]
    private float stamina;
    [SerializeField]
    private float maxStamina;
    [SerializeField]
    private float runDecrease;
    [SerializeField]
    private float jumpDecrease;
    [SerializeField]
    private float jumpCrouchDecrease;
    [SerializeField]
    private float staminaIncrease;
    [SerializeField]
    private float waitTimer;

    private float activeStaminaDecrease;
    private float saveWaitTimer;

    public static bool decrease;
    private bool crouched;
    private bool running;
    private bool jumping;
    private bool waiting;

    public static bool increase;

    //God
    private bool STAMINA;

    private InputSystemKeyboard _inputSystem;

    private void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();

        StaminaManager.maxStamina = maxStamina;
    }

    private void OnEnable()
    {
        _inputSystem.OnRun += SetRunDecrease;
        _inputSystem.OnCrouch += SetCrouchDecrease;
        _inputSystem.OnJump += SetJumpDecrease;
        _inputSystem.OnFullStamina += SetFullStatmina;
    }
    private void OnDisable()
    {
        _inputSystem.OnRun -= SetRunDecrease;
        _inputSystem.OnCrouch -= SetCrouchDecrease;
        _inputSystem.OnJump -= SetJumpDecrease;
        _inputSystem.OnFullStamina -= SetFullStatmina;
    }

    // Start is called before the first frame update
    void Start()
    {
        decrease = false;
        waiting = false;

        saveWaitTimer = waitTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //Choose wich decrement value we need
        if (crouched && jumping && !STAMINA)
        {
            activeStaminaDecrease = jumpCrouchDecrease;
            decrease = true;

            jumping = false;
        }
        else if (jumping && !STAMINA)
        {
            activeStaminaDecrease = jumpDecrease;
            decrease = true;

            jumping = false;
        }
        else if (running && !jumping && !STAMINA)
        {
            if (_inputSystem.axHor != 0 || _inputSystem.axVer != 0)
            {
                activeStaminaDecrease = runDecrease;
                decrease = true;
            }
            else
            {
                decrease = false;
            }
        }
        else if (running && jumping && !STAMINA)
        {
            if (_inputSystem.axHor != 0 || _inputSystem.axVer != 0)
            {
                activeStaminaDecrease = runDecrease + jumpDecrease;
                decrease = true;
            }
            else
            {
                decrease = false;
            }
        }
        else
        {
            decrease = false;
        }

        //Decrease stamina value
        if (decrease && stamina >= 0)
        {
            stamina -= activeStaminaDecrease * Time.deltaTime;

            //Stop and restart the timer to start incrementing the stamina
            waiting = false;
            waitTimer = saveWaitTimer;
        }
        else
        {
            waiting = true;
        }

        //Timer to start regenerate stamina
        if (waiting && stamina <= maxStamina && GroundCheckerManager.isGrounded)
        {
            if (waitTimer <= 0)
            {
                waiting = false;

                stamina += staminaIncrease * Time.deltaTime;

                increase = true;

                if (stamina >= maxStamina)
                {
                    waitTimer = saveWaitTimer;
                }
            }
            else
            {
                waitTimer -= Time.deltaTime;

                increase = false;
            }
        }
        else
        {
            increase = false;
        }

        //Send the current stamina value and max stamina value to the StaminaManager static class
        StaminaManager.currentStamina = stamina;
        StaminaManager.maxStamina = maxStamina;
    }

    //Detects is we are running
    void SetRunDecrease(bool run)
    {
        if (!crouched && GroundCheckerManager.isGrounded)
        {
            running = run;
        }
    }

    //Detects if we are crouch
    void SetCrouchDecrease()
    {
        if (GroundCheckerManager.isGrounded)
        {
            if (!crouched)
            {
                crouched = true;
            }
            else
            {
                crouched = false;
            }
        }
    }

    //Detects if we are jumping
    void SetJumpDecrease()
    {
        if (GroundCheckerManager.isGrounded)
        {
            jumping = true;
        }
    }

    void SetFullStatmina()
    {
        if (STAMINA)
        {
            STAMINA = false;
        }
        else
        {
            STAMINA = true;
        }

        Debug.Log("Stamina: " + STAMINA);
    }

    public bool ReturnStaminaIncrease()
    {
        return increase;
    }

    public bool ReturnStaminaDecrease()
    {
        return decrease;
    }
}
