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

        charge = false;
    }

    // Update is called once per frame
    void Update()
    {
        prefvalue = PlayerPrefs.GetInt("checkpoint");

        if (!charge)
        {
            
            charge = true;
        }

        if (Level01Manager.button1 && Level01Manager.button2
            && Level01Manager.button3 && Level01Manager.button4 && prefvalue == 0)
        {
            PlayerPrefs.SetInt("checkpoint", 1);

            //Level01Manager.playerTrans = player.transform;

            Debug.Log("Saved checkpoint 1");
        }
        if (Level01Manager.buttonPassword1 && Level01Manager.buttonPassword2 
            && Level01Manager.buttonPassword3 && Level01Manager.buttonPassword4 && prefvalue == 1)
        {
            PlayerPrefs.SetInt("checkpoint", 2);

            Debug.Log("Saved checkpoint 2");


            //Level01Manager.playerTrans = player.transform;
        }
        if (Level01Manager.handle && prefvalue == 2)
        {
            PlayerPrefs.SetInt("checkpoint", 3);

            Debug.Log("Saved checkpoint 3");


            //Level01Manager.playerTrans = player.transform;
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
        }
    }

    private void Checkpoint1()
    {
        Level01Manager.button1 = true;
        Level01Manager.button2 = true;
        Level01Manager.button3 = true;
        Level01Manager.button4 = true;

        //player.transform.position = Level01Manager.playerTrans.position;
        //player.transform.rotation = Level01Manager.playerTrans.rotation;

        Debug.Log("CheckPoint1");
    }

    private void Checkpoint2()
    {
        Level01Manager.buttonPassword1 = true;
        Level01Manager.buttonPassword2 = true;
        Level01Manager.buttonPassword3 = true;
        Level01Manager.buttonPassword4 = true;

        Debug.Log("Checkpoint2");
    }

    private void Checkpoint3()
    {
        Debug.Log("Checkpoint3");
    }
}
