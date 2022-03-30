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

    private float startWaitTime;
    public int platformToMove;

    public bool palanca;

    private Vector3 currentPos;

    private Rigidbody _rb;
    private CharacterController _cc;

    // Start is called before the first frame update
    void Start()
    {
        startWaitTime = waitTime;

        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, platPositions[platformToMove].position, speed * Time.deltaTime);

        /*currentPos = Vector3.Lerp(platPositions[0].position, platPositions[platformToMove].position, Mathf.Cos(Time.time / speed * Mathf.PI * 2) * -0.5f + 0.5f);
        _rb.MovePosition(currentPos);*/

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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            //_cc = collision.GetComponent<CharacterController>();

            //_cc = collision.GetComponent<CharacterController>();

            collision.transform.SetParent(transform);
            Debug.Log("Collision Eneter");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            //_cc.Move(new Vector3(collision.transform.position.x + 2f, collision.transform.position.y + 1.5f, collision.transform.position.z + 2f) * Time.deltaTime);
            //collision.transform.position = Vector3.MoveTowards(collision.transform.position, platPositions[platformToMove].position, speed * Time.deltaTime);

            collision.transform.SetParent(null);

            Debug.Log("Collision Exit");
        }
    }
}
