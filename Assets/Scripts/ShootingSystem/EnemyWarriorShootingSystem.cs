using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarriorShootingSystem : MonoBehaviour
{
    public Transform pos;

    public float shotDuration;

    public LayerMask plaerLayer;
    public float range;

    //Timer
    [SerializeField]
    private float waitTime;
    private float startWaitTime;

    private LineRenderer _laserLine;
    private FieldOfView _fieldView;


    // Start is called before the first frame update
    void Start()
    {
        _laserLine = GetComponent<LineRenderer>();
        _fieldView = GetComponent<FieldOfView>();

        startWaitTime = waitTime;
    }

// Update is called once per frame
    void Update()
    {
        if (_fieldView.seePlayer || Input.GetKeyDown(KeyCode.L))
        {
            if (waitTime <= 0)
            {
                StartCoroutine(ShootEffect());

                RaycastHit hit;

                _laserLine.SetPosition(0, pos.position);

                if (Physics.Raycast(pos.position, transform.forward, out hit, range, plaerLayer))
                {
                    Debug.Log("Player hit");

                    _laserLine.SetPosition(1, hit.point);
                }
                else
                {
                    Debug.Log("Object Hit");
                    _laserLine.SetPosition(1, pos.position + (transform.forward * range));
                }

                Debug.Log("Shoot");
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
        _laserLine.enabled = true;

        //Wait for .07 seconds
        yield return shotDuration;

        // Deactivate our line renderer after waiting
        _laserLine.enabled = false;
    }
}
