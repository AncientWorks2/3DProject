using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyWarriorNavigation : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;
    [SerializeField]
    private Transform playerPosition;
    [SerializeField]
    private float normalSpeed;
    [SerializeField]
    private float runSpeed;    

    //Timer
    [SerializeField]
    private float waitTime;
    private float startWaitTime;

    private bool patrol;
    private bool guard;

    //Shock
    public bool shocked;
    public float timeShocked;
    public float shockedSpeed;
    private float startShockedTime;

    private FieldOfView _fieldView;
    private NavMeshAgent _navmesh;

    public event Action<bool> OnWalk = delegate { };

    private void Awake()
    {
        _fieldView = GetComponent<FieldOfView>();
        _navmesh = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startWaitTime = waitTime;

        startShockedTime = timeShocked;
    }

    // Update is called once per frame
    void Update()
    {
        if (_fieldView.ReturnSeePlayer())
        {
            if (shocked)
            {
                _navmesh.speed = shockedSpeed;

                if (timeShocked <= 0)
                {
                    timeShocked = startShockedTime;

                    shocked = false;
                }
                else
                {
                    timeShocked -= Time.deltaTime;
                }                
            }
            else
            {
                _navmesh.speed = runSpeed;
            }

            _navmesh.destination = _fieldView.ReturnTargetTransform().position;

            patrol = false;
            guard = false;
        }
        else if (_navmesh.remainingDistance < 1)
        {
            patrol = false;
            guard = true;

            _navmesh.speed = normalSpeed;

            if (waitTime <= 0)
            {
                waitTime = startWaitTime;

                int p = UnityEngine.Random.Range(0, positions.Length);
                _navmesh.destination = positions[p].position;                
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            
            OnWalk(true);
        }
        else
        {
            patrol = true;
            guard = false;
        }
    }

    public bool ReturnPatrol()
    {
        return patrol;
    }

    public bool ReturnGuard()
    {
        return guard;
    }
}
