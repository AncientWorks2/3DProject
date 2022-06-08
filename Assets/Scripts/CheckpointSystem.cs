using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    /*[SerializeField]
    private Transform player;*/

    private int prefvalue;
    private bool charge;

    // Start is called before the first frame update
    void Start()
    {
        prefvalue = PlayerPrefs.GetInt("checkpoint");

        CheckpointChecker();
    }

    // Update is called once per frame
    void Update()
    {
        prefvalue = PlayerPrefs.GetInt("checkpoint");

        if (Level01Manager.button1 && Level01Manager.button2
            && Level01Manager.button3 && Level01Manager.button4 && prefvalue == 0)
        {
            PlayerPrefs.SetInt("checkpoint", 1);

            Debug.Log("Saved checkpoint 1");
        }
        if (Level01Manager.buttonPassword1 && Level01Manager.buttonPassword2 
            && Level01Manager.buttonPassword3 && Level01Manager.buttonPassword4 && prefvalue == 1)
        {
            PlayerPrefs.SetInt("checkpoint", 2);

            Debug.Log("Saved checkpoint 2");
        }
        if (Level01Manager.handle && prefvalue == 2)
        {
            PlayerPrefs.SetInt("checkpoint", 3);

            Debug.Log("Saved checkpoint 3");
        }
        if (Level02Manager.objectPicked && !Level02Manager.keypadDoorOpened && prefvalue == 3)
        {
            PlayerPrefs.SetInt("checkpoint", 4);

            Debug.Log("Saved checkpoint 4");
        }
        if (Level02Manager.bigDoorOpnened && prefvalue == 4)
        {
            PlayerPrefs.SetInt("checkpoint", 5);

            Debug.Log("Saved checkpoint 5");
        }
        if (Level02Manager.redBox && Level02Manager.blueBox && Level02Manager.greenBox 
            && Level02Manager.yellowBox && prefvalue == 5)
        {
            PlayerPrefs.SetInt("checkpoint", 6);

            Debug.Log("Saved checkpoint 6");
        }
    }

    private void CheckpointChecker()
    {
        if (prefvalue > 0)
        {
            Checkpoint1();
            Debug.Log("Charging checkpoint 1");
        }
        if (prefvalue > 1)
        {
            Checkpoint2();
            Debug.Log("Charging checkpoint 2");
        }
        if (prefvalue > 2)
        {
            Checkpoint3();
            Debug.Log("Charging checkpoint 3");
        }
        if (prefvalue > 3)
        {
            Checkpoint4();
            Debug.Log("Charging checkpoint 4");
        }
        if (prefvalue > 4)
        {
            Checkpoint5();
            Debug.Log("Charging checkpoint 5");
        }
        if (prefvalue > 5)
        {
            Checkpoint6();
            Debug.Log("Charging checkpoint 6");
        }
    }

    private void Checkpoint1()
    {
        Level01Manager.button1 = true;
        Level01Manager.button2 = true;
        Level01Manager.button3 = true;
        Level01Manager.button4 = true;
    }

    private void Checkpoint2()
    {
        Level01Manager.buttonPassword1 = true;
        Level01Manager.buttonPassword2 = true;
        Level01Manager.buttonPassword3 = true;
        Level01Manager.buttonPassword4 = true;
    }

    private void Checkpoint3()
    {
        Level01Manager.handle = true;
    }

    private void Checkpoint4()
    {
        //Level02Manager.objectPicked = true;

        GameObject.FindWithTag("Player").GetComponent<PickupObjects>().enabled = true;
        Level02Manager.keypadDoorOpened = false;
    }

    private void Checkpoint5()
    {
        Level02Manager.bigDoorOpnened = true;
    }

    private void Checkpoint6()
    {
        Level02Manager.yellowBox = true;
        Level02Manager.redBox = true;
        Level02Manager.greenBox = true;
        Level02Manager.blueBox = true;
    }
}
