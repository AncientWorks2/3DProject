using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEngine : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform[] platPositions;
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private float distance;
    [SerializeField]
    private GameObject button;

    private float startWaitTime;
    private int platformToMove;

    public bool palanca;

    private PlatformController _platformContr;

    private void Awake()
    {
        _platformContr = button.GetComponent<PlatformController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startWaitTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        palanca = _platformContr.ReturnInOn();

        if (Level01Manager.button1 && Level01Manager.button2 && Level01Manager.button3 && Level01Manager.button4)
        {
            transform.position = Vector3.MoveTowards(transform.position, platPositions[platformToMove].position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, platPositions[platformToMove].position) < distance)
            {
                if (waitTime <= 0)
                {
                    waitTime = startWaitTime;

                    if (platformToMove == 0)
                    {
                        if (palanca)
                        {
                            platformToMove = 1;
                        }
                        else
                        {
                            platformToMove = 2;
                        }
                    }
                    else
                    {
                        platformToMove = 0;
                    }
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
