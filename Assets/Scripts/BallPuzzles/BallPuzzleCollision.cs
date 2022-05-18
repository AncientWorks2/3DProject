using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPuzzleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        OnTrigger(collision);
    }

    protected virtual void OnTrigger(Collider other)
    {
        //other.gameObject.GetComponent<BallPuzzleSystem>().TriggeredBox();
    }

}
