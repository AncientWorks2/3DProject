using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavigation : MonoBehaviour
{
    private NavMeshAgent navmesh;
    public Transform[] positions;
    public Transform finalDestination;

    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            navmesh.destination = finalDestination.position;
        }

        if (navmesh.remainingDistance < 1)
        {
            int p = UnityEngine.Random.Range(0, positions.Length);
            navmesh.destination = positions[p].position;
        }


    }
}
