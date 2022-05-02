using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField]
    public float radius;
    [Range(0, 360)]
    public float angle;
    [SerializeField]
    private LayerMask targetMask;
    [SerializeField]
    private LayerMask obstructionMask;
    [SerializeField]
    private Light viewLight;
    [SerializeField]
    private Color viewColor;

    //Send info
    public bool seePlayer;
    public Transform target;

    private Color spotlightOriginalColor;

    void Start()
    {
        spotlightOriginalColor = viewLight.color;
    }

    void Update()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    seePlayer = true;

                    ChangeColor(seePlayer);
                }
                else
                {
                    seePlayer = false;

                    ChangeColor(seePlayer);
                }
            }
            else
            {
                seePlayer = false;

                ChangeColor(seePlayer);
            }
        }
        else if (seePlayer)
        {
            seePlayer = false;

            ChangeColor(seePlayer);
        }
    }

    private void ChangeColor(bool seeing)
    {
        if (seeing)
        {
            viewLight.color = viewColor;
        }
        else
        {
            viewLight.color = spotlightOriginalColor;
        }
    }
}
