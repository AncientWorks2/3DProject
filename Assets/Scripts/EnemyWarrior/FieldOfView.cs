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

    //Debug
    [SerializeField]
    private bool drawGizmos;

    //Send info
    private bool seePlayer;
    private Transform target;
    private RaycastHit hit;

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

                if (!Physics.Raycast(transform.position, directionToTarget, out hit, distanceToTarget, obstructionMask))
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

    public bool ReturnSeePlayer()
    {
        return seePlayer;
    }

    public Transform ReturnTargetTransform()
    {
        return target;
    }

    public RaycastHit ReturnHit()
    {
        return hit;
    }

    private void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            Gizmos.color = Color.yellow;

            Gizmos.DrawWireSphere(transform.position, radius);

            Vector3 viewAngle01 = DirectionFromAngle(transform.eulerAngles.y, -angle / 2);
            Vector3 viewAngle02 = DirectionFromAngle(transform.eulerAngles.y, angle / 2);

            Gizmos.DrawLine(transform.position, transform.position + viewAngle01 * radius);
            Gizmos.DrawLine(transform.position, transform.position + viewAngle02 * radius);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
