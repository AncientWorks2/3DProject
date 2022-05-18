using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShockWaveSystem : MonoBehaviour
{
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask targetMask;
    [SerializeField]
    private float speedShock;
    [SerializeField]
    private float shockTime;

    //Timer
    [SerializeField]
    private float waitTime;
    private float startWaitTime;
    private bool waitingTime;

    //Canvas feedback
    [SerializeField]
    private Image loadShock;

    //Debug
    [SerializeField]
    private bool drawGizmos;

    private Collider[] rangeChecks;

    public bool shock;
    public bool activeShock;

    private EnemyWarriorNavigation _enNav;
    private InputSystemKeyboard _input;

    public event Action OnShock = delegate { };

    private void Awake()
    {
        _input = GetComponent<InputSystemKeyboard>();
    }

    private void OnEnable()
    {
        _input.OnShock += SetShock;
    }

    private void OnDisable()
    {
        _input.OnShock -= SetShock;
    }

    // Start is called before the first frame update
    void Start()
    {
        startWaitTime = waitTime;

        activeShock = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (shock && activeShock)
        {
            rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

                for (int i = 0; i < rangeChecks.Length; i++)
                {
                    _enNav = rangeChecks[i].GetComponent<EnemyWarriorNavigation>();

                    _enNav.shocked = shock;
                    _enNav.shockedSpeed = speedShock;
                    _enNav.timeShocked = shockTime;
                }

            OnShock();

            shock = false;
            activeShock = false;
            loadShock.fillAmount = 0;
        }

        if (waitingTime)
        {
            if (waitTime <= 0)
            {
                activeShock = true;
                waitingTime = false;
            }
            else
            {
                waitTime -= Time.deltaTime;

                loadShock.fillAmount += Time.deltaTime/startWaitTime;
            }
        }

        /*if (loadShock.fillAmount <= waitTime && waitingTime)
        {
            loadShock.fillAmount += Time.deltaTime;
        }*/
    }

    private void SetShock()
    {
        if (activeShock)
        {
            shock = true;
            waitingTime = true;

            waitTime = startWaitTime;
        }
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}