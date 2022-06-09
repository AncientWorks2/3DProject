using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterHealthSystem : HealthSystem
{
    [SerializeField]
    private float waitTimer;
    [SerializeField]
    private float healthIncrease;

    private float initialWaitTime;
    private bool waiting;

    public bool INVENCIBLE;

    public static bool hit;

    public static bool increase;

    private InputSystemKeyboard _inputSystem;

    public event Action OnHealthZero = delegate { };

    private void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();
        INVENCIBLE = false;

        HealthManager.maxPlayerHealth = maxHealth;
        HealthManager.playerHealth = health;
    }

    private void OnEnable()
    {
        _inputSystem.OnInvencible += SetInvencible;
    }

    private void OnDisable()
    {
        _inputSystem.OnInvencible -= SetInvencible;
    }

    void Start()
    {
        initialWaitTime = waitTimer;

        hit = false;
    }

    public override void RestHealth(int restHealthValue)
    {
        if (!INVENCIBLE)
        {
            health -= restHealthValue;

            waitTimer = initialWaitTime;

            StartCoroutine(GetHit());
        }

        if (health <= 0)
        {
            OnHealthZero();
        }

        HealthManager.maxPlayerHealth = maxHealth;
        HealthManager.playerHealth = health;
    }

    private void Update()
    {
        HealthManager.playerHealth = health;

        if (health < maxHealth && _inputSystem.axHor == 0 && _inputSystem.axVer == 0)
        {
            if (waitTimer <= 0)
            {
                health += healthIncrease * Time.deltaTime;

                increase = true;

                if (health >= maxHealth)
                {
                    waitTimer = initialWaitTime;
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
            waitTimer = initialWaitTime;

            increase = false;
        }
    }

    public void SetInvencible()
    {
        if (INVENCIBLE)
        {
            INVENCIBLE = false;
        }
        else
        {
            INVENCIBLE = true;
        }
    }

    IEnumerator GetHit()
    {
        hit = true;

        yield return new WaitForSeconds(1);

        hit = false;
    }

    public float ReturnHealth()
    {
        return health;
    }

    public float ReturnMaxHealth()
    {
        return maxHealth;
    }

    public bool ReturnHealthIncrease()
    {
        return increase;
    }
}
