using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    private DoorController _doorCtr;


    private void Awake()
    {
        _doorCtr = GetComponent<DoorController>();    
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("checkpoint") < 4)
        {
            Level02Manager.keypadDoorOpened = _doorCtr.lockedByPassword;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Level02Manager.keypadDoorOpened)
        {
            _doorCtr.lockedByPassword = false;
        }
    }
}
