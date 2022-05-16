using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class DieSystem : MonoBehaviour
{

    private CharacterHealthSystem _charHealth;

    private void Awake()
    {
        _charHealth = GetComponent<CharacterHealthSystem>();
    }

    private void OnEnable()
    {
        _charHealth.OnHealthZero += Die;
    }

    private void OnDisable()
    {
        _charHealth.OnHealthZero -= Die;
    }

    private void Start()
    {
    }

    private void Die()
    {
        SceneManager.LoadScene("DieScene");
    }
}