using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWarriorNavigation : MonoBehaviour
{
    [SerializeField]
    private Transform[] positions;
    [SerializeField]
    private Transform playerPosition;
    [SerializeField]
    private float speed;
    

    //Timer
    [SerializeField]
    private float waitTime;
    private float startWaitTime;

    private FieldOfView _fieldView;
    private NavMeshAgent _navmesh;

    private void Awake()
    {
        _fieldView = GetComponent<FieldOfView>();
        _navmesh = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {

        startWaitTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_fieldView.ReturnSeePlayer())
        {
            _navmesh.destination = _fieldView.ReturnTargetTransform().position;
        }
        else if (_navmesh.remainingDistance < 1)
        {
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
            
        }


    }
}
