using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public Transform gameManager;
 
    private float size;

    Camera cameraC;
    GameManager gameManagerC;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerC = gameManager.GetComponent<GameManager>();
        cameraC = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerC.IsCinematicMode()) { return; }

        //transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void SetSize(float size)
    {
        cameraC.orthographicSize = size;
    }
}
