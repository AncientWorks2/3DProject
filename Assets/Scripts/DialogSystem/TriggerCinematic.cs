using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCinematic : MonoBehaviour
{
    public int index;
    public Transform gameManager;

    bool fired;

    GameManager gameManagerC;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerC = gameManager.GetComponent<GameManager>();

        fired = false;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnTriggerEnter(Collider other)
    {
        if(!fired)
        {
            gameManagerC.OnTriggerCinematic(index);

            fired = true;
        }

    }
}
