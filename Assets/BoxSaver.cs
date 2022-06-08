using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSaver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("checkpoint") < 3)
        {
            Level01Manager.boxTrans = gameObject.transform;
        }

        //gameObject.transform.position = Level01Manager.boxTrans.position;
        //gameObject.transform.rotation = Level01Manager.boxTrans.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("checkpoint") == 3)
        {
            Level01Manager.boxTrans = gameObject.transform;
        }
    }
}
