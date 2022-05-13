using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DieSystem : MonoBehaviour
{
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private Image panelImage;
    [SerializeField]
    private Color panelColor;
    [SerializeField]
    private Text panelDie;

    private float initialWaitiTime;

    private CharacterHealthSystem _charHealth;
    private Image _img;

    private void Awake()
    {
        _charHealth = GetComponent<CharacterHealthSystem>();
        _img = panelImage.GetComponent<Image>();
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
        initialWaitiTime = waitTime;
    }

    private void Die()
    {
        SceneManager.LoadScene("DieScene");
    }
}