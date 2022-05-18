using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyWarriorShootingSystem : ShootingSystem
{
    [SerializeField]
    private float shotDuration;
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private LayerMask otherLayers;
    [SerializeField]
    private float raycastRange;

    //Timer
    [SerializeField]
    private float waitTime;
    private float startWaitTime;

    private LineRenderer _lineRend;
    private FieldOfView _fieldView;
    private CharacterHealthSystem _charHealth;

    public event Action OnShot = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        _lineRend = GetComponent<LineRenderer>();
        _fieldView = GetComponent<FieldOfView>();

        startWaitTime = waitTime;
    }

    // Update is called once per frame
    private void Update()
    {
        Shoot();
    }

    public override void Shoot()
    {
        if (_fieldView.ReturnSeePlayer())
        {
            if (waitTime <= 0)
            {
                waitTime = startWaitTime;

                StartCoroutine(ShootEffect());

                RaycastHit hit;

                //Reset line renerer position
                _lineRend.SetPosition(0, shotPoint[0].position);

                if (Physics.Raycast(shotPoint[0].position, transform.forward, out hit, raycastRange, playerLayer))
                {
                    Debug.Log("Player hit");

                    //Draw line renderer to the player if hits with it
                    _lineRend.SetPosition(1, _fieldView.ReturnHit().point);

                    _charHealth = hit.transform.gameObject.GetComponent<CharacterHealthSystem>();

                    _charHealth.RestHealth(damage);
                }
                else
                {
                    Debug.Log("Object Hit");

                    //Draw line on the range we shoot
                    _lineRend.SetPosition(1, shotPoint[0].position + (transform.forward * raycastRange));
                }

                OnShot();
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator ShootEffect()
    {
        // Turn on our line renderer
        _lineRend.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        _lineRend.enabled = false;
    }
}
