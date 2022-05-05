using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyLoad : MonoBehaviour
{
    private static DontDestroyLoad _instance;
    //public static DontDestroyLoad Instance => _instance;

    // Start is called before the first frame update
    /*void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);


            Debug.Log("instance == null");
        }
        else
        {
            // Ya hay otro objeto creado
            Destroy(this);
        }
    }*/

    void Start()
    {
        if (_instance == null)
        {
            // El objeto es el primero de su tipo

            GameObject.DontDestroyOnLoad(gameObject);
            _instance = this;
        }
        else
        {
            // Ya hay otro objeto creado
            GameObject.Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
